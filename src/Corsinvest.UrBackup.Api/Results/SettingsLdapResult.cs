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
    public partial class SettingsLdapResult
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
            [JsonProperty("ldap_class_key_name")]
            public string LdapClassKeyName { get; set; }

            [JsonProperty("ldap_class_rights_map")]
            public string LdapClassRightsMap { get; set; }

            [JsonProperty("ldap_group_class_query")]
            public string LdapGroupClassQuery { get; set; }

            [JsonProperty("ldap_group_key_name")]
            public string LdapGroupKeyName { get; set; }

            [JsonProperty("ldap_group_rights_map")]
            public string LdapGroupRightsMap { get; set; }

            [JsonProperty("ldap_login_enabled")]
            public bool LdapLoginEnabled { get; set; }

            [JsonProperty("ldap_server_name")]
            public string LdapServerName { get; set; }

            [JsonProperty("ldap_server_port")]
            public long LdapServerPort { get; set; }

            [JsonProperty("ldap_username_prefix")]
            public string LdapUsernamePrefix { get; set; }

            [JsonProperty("ldap_username_suffix")]
            public string LdapUsernameSuffix { get; set; }
        }
    }
}


