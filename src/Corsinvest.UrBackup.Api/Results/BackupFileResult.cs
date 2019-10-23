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
    public class BackupFileResult : BaseResult
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

        public class File
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


