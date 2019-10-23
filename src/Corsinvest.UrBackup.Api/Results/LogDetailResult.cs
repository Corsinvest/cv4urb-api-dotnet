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
    public class LogDetailResult : BaseResult
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

        public class Client
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class LogDetail
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
