/*
 * This file is part of the cv4urb-api-dotnet https://github.com/Corsinvest/cv4urb-api-dotnet,
 *
 * This source file is available under two different licenses:
 * - GNU General Public License version 3 (GPLv3)
 * - Corsinvest Enterprise License (CEL)
 * Full copyright and license information is available in
 * LICENSE.md which is distributed with this source code.
 *
 * Copyright (C) 2016 Corsinvest Srl	GPLv3 and CEL
 */

using Newtonsoft.Json;

namespace Corsinvest.UrBackup.Api.Results
{
    public class SettingsLdapResult
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

        public class NavitemsSettings
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

        public class Client
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

        public class Group
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class SettingsSettings
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


