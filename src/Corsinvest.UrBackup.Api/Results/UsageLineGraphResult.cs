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
using System;
using System.Collections.Generic;

namespace Corsinvest.UrBackup.Api.Results
{
    public class UsageLineGraphResult : BaseResult
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("ylabel")]
        public string Ylabel { get; set; }

        public partial class Datum
        {
            [JsonProperty("data")]
            public double Data { get; set; }

            [JsonProperty("xlabel")]
            public DateTimeOffset Xlabel { get; set; }
        }
    }
}


