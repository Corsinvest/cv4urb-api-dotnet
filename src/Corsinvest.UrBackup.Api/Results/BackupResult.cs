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
    public class BackupResult : BaseResult
    {
        [JsonProperty("backup_images")]
        public List<Backup> BackupImages { get; set; }

        [JsonProperty("backups")]
        public List<Backup> Backups { get; set; }

        [JsonProperty("can_archive")]
        public bool CanArchive { get; set; }

        [JsonProperty("can_delete")]
        public bool CanDelete { get; set; }

        [JsonProperty("clientid")]
        public long Clientid { get; set; }

        [JsonProperty("clientname")]
        public string Clientname { get; set; }

        public class Backup
        {
            [JsonProperty("archived")]
            public long Archived { get; set; }

            [JsonProperty("backuptime")]
            public long Backuptime { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("incremental")]
            public long Incremental { get; set; }

            [JsonProperty("letter", NullValueHandling = NullValueHandling.Ignore)]
            public string Letter { get; set; }

            [JsonProperty("size_bytes")]
            public long SizeBytes { get; set; }

            [JsonProperty("disable_delete", NullValueHandling = NullValueHandling.Ignore)]
            public bool? DisableDelete { get; set; }
        }
    }
}


