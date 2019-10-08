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

using Corsinvest.UrBackup.Api.Results;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Usage
    /// </summary>
    public partial class Usage
    {
        private UrBackupClient _client;

        internal Usage(UrBackupClient client) => _client = client;

        /// <summary>
        /// Get usage
        /// </summary>
        /// <returns></returns>
        public Result<UsageResult> Get() => _client.Get<UsageResult>("usage");

        /// <summary>
        /// Recalculate
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> Recalculate() => _client.Get("usage", "recalculate", true);

        /// <summary>
        /// Data Pie Graph
        /// </summary>
        /// <returns></returns>
        public Result<UsagePieGraphResult> GetPieGraph() => _client.Get<UsagePieGraphResult>("piegraph");

        /// <summary>
        /// Data line graph
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Result<UsageLineGraphResult> GetLineGraph(UsageLineGraphScale scale)
            => _client.Get<UsageLineGraphResult>("usagegraph", (char)scale);
    }
}