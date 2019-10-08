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
    public partial class BackupFileResult : BaseResult
    {
        [JsonProperty("backupid")]
        public long Backupid { get; set; }

        [JsonProperty("backuptime")]
        public long Backuptime { get; set; }

        [JsonProperty("can_restore")]
        public bool CanRestore { get; set; }

        [JsonProperty("clientid")]
        public long Clientid { get; set; }

        [JsonProperty("clientname")]
        public string Clientname { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        public partial class File
        {
            [JsonProperty("access")]
            public long Access { get; set; }

            [JsonProperty("creat")]
            public long Creat { get; set; }

            [JsonProperty("dir")]
            public bool Dir { get; set; }

            [JsonProperty("mod")]
            public long Mod { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}


