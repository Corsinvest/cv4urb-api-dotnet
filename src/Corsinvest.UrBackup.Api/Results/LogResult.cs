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
    public partial class LogResult : BaseResult
    {
        [JsonProperty("HAS_MAIL_START")]
        public string HasMailStart { get; set; }

        [JsonProperty("HAS_MAIL_STOP")]
        public string HasMailStop { get; set; }

        [JsonProperty("all_clients")]
        public bool AllClients { get; set; }

        [JsonProperty("can_report_script_edit")]
        public bool CanReportScriptEdit { get; set; }

        [JsonProperty("clients")]
        public List<Client> Clients { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("has_user")]
        public bool HasUser { get; set; }

        [JsonProperty("ll")]
        public long Ll { get; set; }

        [JsonProperty("log_right_clients")]
        public List<Client> LogRightClients { get; set; }

        [JsonProperty("logs")]
        public List<Log> Logs { get; set; }

        [JsonProperty("report_loglevel")]
        public string ReportLoglevel { get; set; }

        [JsonProperty("report_mail")]
        public string ReportMail { get; set; }

        [JsonProperty("report_sendonly")]
        public string ReportSendonly { get; set; }

        public partial class Client
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class Log
        {
            [JsonProperty("errors")]
            public long Errors { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("image")]
            public long Image { get; set; }

            [JsonProperty("incremental")]
            public long Incremental { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("restore")]
            public long Restore { get; set; }

            [JsonProperty("resumed")]
            public long Resumed { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("warnings")]
            public long Warnings { get; set; }
        }
    }
}
