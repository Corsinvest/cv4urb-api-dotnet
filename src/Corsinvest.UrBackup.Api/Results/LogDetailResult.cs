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
using System.Collections.Generic;

namespace Corsinvest.UrBackup.Api.Results
{
    public partial class LogDetailResult : BaseResult
    {
        [JsonProperty("all_clients")]
        public bool AllClients { get; set; }

        [JsonProperty("clients")]
        public List<Client> Clients { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("has_user")]
        public bool HasUser { get; set; }

        [JsonProperty("log")]
        public LogDetail Log { get; set; }

        [JsonProperty("log_right_clients")]
        public List<Client> LogRightClients { get; set; }

        public partial class Client
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class LogDetail
        {
            [JsonProperty("clientname")]
            public string Clientname { get; set; }

            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }
        }
    }
}
