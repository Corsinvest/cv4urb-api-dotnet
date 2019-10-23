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
    public class LogResult : BaseResult
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

        public class Client
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Log
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
