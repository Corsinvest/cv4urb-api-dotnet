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
    public class BackupClientResult : BaseResult
    {
        [JsonProperty("clients")]
        public List<Client> Clients { get; set; }

        public class Client
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("lastbackup")]
            public long Lastbackup { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}


