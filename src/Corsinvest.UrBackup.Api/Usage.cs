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

using Corsinvest.UrBackup.Api.Results;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Usage
    /// </summary>
    public class Usage
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