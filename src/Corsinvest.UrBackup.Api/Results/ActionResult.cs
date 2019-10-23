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
    public class ActionResult : BaseResult
    {
        [JsonProperty("lastacts")]
        public List<LastAction> LastActions { get; set; }

        [JsonProperty("progress")]

        public List<ProgressAction> Progress { get; set; }

        public class LastAction
        {
            [JsonProperty("backuptime")]
            public long Backuptime { get; set; }

            [JsonProperty("clientid")]
            public long Clientid { get; set; }

            [JsonProperty("del")]
            public bool Del { get; set; }

            [JsonProperty("details")]
            public string Details { get; set; }

            [JsonProperty("duration")]
            public long Duration { get; set; }

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

            [JsonProperty("size_bytes")]
            public long SizeBytes { get; set; }
        }

        public class ProgressAction
        {
            [JsonProperty("action")]
            public long Action { get; set; }

            [JsonProperty("can_show_backup_log")]
            public bool CanShowBackupLog { get; set; }

            [JsonProperty("can_stop_backup")]
            public bool CanStopBackup { get; set; }

            [JsonProperty("clientid")]
            public long Clientid { get; set; }

            [JsonProperty("detail_pc")]
            public long DetailPc { get; set; }

            [JsonProperty("details")]
            public string Details { get; set; }

            [JsonProperty("done_bytes")]
            public long DoneBytes { get; set; }

            [JsonProperty("eta_ms")]
            public long EtaMs { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("logid")]
            public long Logid { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("past_speed_bpms")]
            public List<double> PastSpeedBpms { get; set; }

            [JsonProperty("paused")]
            public bool Paused { get; set; }

            [JsonProperty("pcdone")]
            public long Pcdone { get; set; }

            [JsonProperty("queue")]
            public long Queue { get; set; }

            [JsonProperty("speed_bpms")]
            public double SpeedBpms { get; set; }

            [JsonProperty("total_bytes")]
            public long TotalBytes { get; set; }
        }
    }
}
