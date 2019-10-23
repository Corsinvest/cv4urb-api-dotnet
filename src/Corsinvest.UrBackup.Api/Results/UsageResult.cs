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
    public class UsageResult : BaseResult
    {
        [JsonProperty("reset_statistics")]
        public bool ResetStatistics { get; set; }

        [JsonProperty("usage")]
        public List<UsageDetail> Usage { get; set; }

        public class UsageDetail
        {
            [JsonProperty("files")]
            public long Files { get; set; }

            [JsonProperty("images")]
            public long Images { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("used")]
            public long Used { get; set; }
        }
    }
}


