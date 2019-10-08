/*
 * This file is part of the cv4urb-api-dotnet https://github.com/Corsinvest/cv4pve-api-dotnet,
 * Copyright (C) 2016 Corsinvest Srl
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Corsinvest.UrBackup.Api.Results;
using System.Collections.Generic;
using System.Linq;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Settings
    /// </summary>
    public class Settings
    {
        private readonly UrBackupClient _client;

        internal Settings(UrBackupClient client) => _client = client;

        /// <summary>
        /// General
        /// </summary>
        public Context<SettingsGeneralResult> GetGeneral()
            => new Context<SettingsGeneralResult>(_client, "general");

        /// <summary>
        /// Mail
        /// </summary>
        public Context<SettingsMailResult> GetMail()
            => new Context<SettingsMailResult>(_client, "mail");

        /// <summary>
        /// Ldap
        /// </summary>
        public Context<SettingsLdapResult> GetLdap()
            => new Context<SettingsLdapResult>(_client, "ldap");

        /// <summary>
        /// Get client
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public Context<SettingsClientResult> GetClient(long clientId, bool overwrite)
            => new Context<SettingsClientResult>(_client, "clientsettings", clientId, overwrite);

        /// <summary>
        /// Get group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public Context<SettingsGroupResult> GetGroup(long groupId, bool overwrite)
            => new Context<SettingsGroupResult>(_client, "clientsettings", groupId * -1, overwrite);

        /// <summary>
        /// Add group
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GroupAdd(string name)
            => _client.Get("settings", "groupadd", name).PropertyExists("add_ok");

        /// <summary>
        /// Remove group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public bool GroupRemove(long groupId)
            => _client.Get("settings", "groupremove", groupId).PropertyExists("delete_ok");

        /// <summary>
        /// Group members change
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="clientsId"></param>
        /// <returns></returns>
        public Result<dynamic> GroupMembersChange(long groupId, IEnumerable<long> clientsId)
            => _client.Get("settings",
                           "sa", "clientsettings_save",
                           "group_mem_changes", string.Join(";", clientsId.Select(a => $"{groupId}={a}")));


        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passwordMD5"></param>
        /// <param name="salt"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        public Result<dynamic> UserAdd(string name,
                                       string passwordMD5,
                                       string salt,
                                       string rights)
            => _client.Get("settings",
                           "useradd", name,
                           "pwmd5", passwordMD5,
                           "salt", salt,
                           "rights", rights);

        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Result<dynamic> UserRemove(long userId) => _client.Get("settings", "removeuser", userId);

        /// <summary>
        /// User update right
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        public Result<dynamic> UserUpdateRight(long userId, string rights)
            => _client.Get("settings", "userid", userId, "updaterights", rights);

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        public Result<SettingsListUserResult> GetUsers() => _client.Get<SettingsListUserResult>("listusers");

        /// <summary>
        /// Settings context
        /// </summary>
        public class Context<TResult>
        {
            private readonly UrBackupClient _client;
            private readonly string _context;
            private readonly long _clientId;
            private readonly bool forClient;
            private readonly bool _overwrite;

            internal Context(UrBackupClient client, string context)
            {
                _client = client;
                _context = context;
            }

            internal Context(UrBackupClient client, string context, long clientId, bool overwrite)
                : this(client, context)
            {
                _clientId = clientId;
                forClient = true;
                _overwrite = overwrite;
            }

            /// <summary>
            /// Get settings context
            /// </summary>
            /// <returns></returns>
            public Result<TResult> Get() => _client.Get<TResult>("settings", "sa", _context);

            /// <summary>
            /// Set value of key
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public Result<dynamic> Set(string key, object value) => SetMultiple(new object[] { key, value });

            /// <summary>
            /// Set setting context
            /// </summary>
            /// <param name="keyValue"></param>
            /// <returns></returns>
            public Result<dynamic> SetMultiple(params object[] keyValue)
            {
                var data = new List<object>();
                data.AddRange(new object[] { "sa", $"{_context}_save" });

                if (forClient)
                {
                    data.AddRange(new object[] { "t_clientid", _clientId });
                    data.AddRange(new object[] { "overwrite", _overwrite });
                }

                data.AddRange(keyValue);

                return _client.Get("settings", keyValue);
            }
        }
    }
}