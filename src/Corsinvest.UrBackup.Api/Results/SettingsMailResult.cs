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
    public class SettingsMailResult : BaseResult
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