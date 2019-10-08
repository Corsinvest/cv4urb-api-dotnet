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

using Newtonsoft.Json;

namespace Corsinvest.UrBackup.Api.Results
{
    public partial class SettingsMailResult : BaseResult
    {
        [JsonProperty("ONLY_WIN32_BEGIN")]
        public string OnlyWin32Begin { get; set; }

        [JsonProperty("ONLY_WIN32_END")]
        public string OnlyWin32End { get; set; }

        [JsonProperty("navitems")]
        public NavitemsSettings Navitems { get; set; }

        [JsonProperty("sa")]
        public string Sa { get; set; }

        [JsonProperty("settings")]
        public SettingsSettings Settings { get; set; }

        public partial class NavitemsSettings
        {
            [JsonProperty("clients")]
            public Client[] Clients { get; set; }

            [JsonProperty("disable_change_pw")]
            public bool DisableChangePw { get; set; }

            [JsonProperty("general")]
            public bool General { get; set; }

            [JsonProperty("groupmod")]
            public bool Groupmod { get; set; }

            [JsonProperty("groups")]
            public Group[] Groups { get; set; }

            [JsonProperty("internet")]
            public bool Internet { get; set; }

            [JsonProperty("ldap")]
            public bool Ldap { get; set; }

            [JsonProperty("mail")]
            public bool Mail { get; set; }

            [JsonProperty("users")]
            public bool Users { get; set; }
        }

        public partial class Client
        {
            [JsonProperty("group")]
            public long Group { get; set; }

            [JsonProperty("groupname")]
            public string Groupname { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("override")]
            public bool Override { get; set; }
        }

        public partial class Group
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class SettingsSettings
        {
            [JsonProperty("mail_admin_addrs")]
            public string MailAdminAddrs { get; set; }

            [JsonProperty("mail_check_certificate")]
            public bool MailCheckCertificate { get; set; }

            [JsonProperty("mail_from")]
            public string MailFrom { get; set; }

            [JsonProperty("mail_password")]
            public string MailPassword { get; set; }

            [JsonProperty("mail_servername")]
            public string MailServername { get; set; }

            [JsonProperty("mail_serverport")]
            public long MailServerport { get; set; }

            [JsonProperty("mail_ssl_only")]
            public bool MailSslOnly { get; set; }

            [JsonProperty("mail_username")]
            public string MailUsername { get; set; }
        }
    }
}