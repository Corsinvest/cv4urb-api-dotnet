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
    public partial class BackupResult : BaseResult
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

        public partial class Backup
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


