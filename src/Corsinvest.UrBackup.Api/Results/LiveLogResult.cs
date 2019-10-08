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
    public partial class LiveLogResult
    {
        [JsonProperty("logdata")]
        public List<Logdatum> Logdata { get; set; }

        public partial class Logdatum
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("loglevel")]
            public long Loglevel { get; set; }

            [JsonProperty("msg")]
            public string Msg { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }
        }
    }
}
