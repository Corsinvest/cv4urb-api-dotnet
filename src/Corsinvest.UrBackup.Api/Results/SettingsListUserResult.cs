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
using System.Collections.Generic;

namespace Corsinvest.UrBackup.Api.Results
{
    public class SettingsListUserResult : BaseResult
    {
        [JsonProperty("ONLY_WIN32_BEGIN")]
        public string OnlyWin32Begin { get; set; }

        [JsonProperty("ONLY_WIN32_END")]
        public string OnlyWin32End { get; set; }

        [JsonProperty("navitems")]
        public NavitemsSettings Navitems { get; set; }

        [JsonProperty("sa")]
        public string Sa { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }

        public class NavitemsSettings
        {
            [JsonProperty("clients")]
            public List<Client> Clients { get; set; }

            [JsonProperty("disable_change_pw")]
            public bool DisableChangePw { get; set; }

            [JsonProperty("general")]
            public bool General { get; set; }

            [JsonProperty("groupmod")]
            public bool Groupmod { get; set; }

            [JsonProperty("groups")]
            public List<Group> Groups { get; set; }

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

        public class User
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("rights")]
            public List<Right> Rights { get; set; }
        }

        public class Right
        {
            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("right")]
            public string RightRight { get; set; }
        }
    }
}