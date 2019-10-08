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
using System.Collections.Generic;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Logs
    /// </summary>
    public class Logs
    {
        private UrBackupClient _client;

        internal Logs(UrBackupClient client) => _client = client;

        /// <summary>
        /// Get live log
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="lastLogId"></param>
        /// <returns></returns>
        public Result<LiveLogResult> GetLive(long clientId, long lastLogId)
            => _client.Get<LiveLogResult>("livelog", "clientid", clientId, "lastid", lastLogId);

        /// <summary>
        /// Get logs
        /// </summary>
        /// <returns></returns>
        public Result<LogResult> Get() => _client.Get<LogResult>("logs");

        /// <summary>
        /// Get Log detail
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public Result<LogDetailResult> Get(long logId) => _client.Get<LogDetailResult>("logs", "logid", logId);

        /// <summary>
        /// Save report settings
        /// </summary>
        /// <param name="emails"></param>
        /// <param name="reportSendOnly"></param>
        /// <param name="reportLogLevel"></param>
        /// <returns></returns>
        public Result<dynamic> SaveReport(IEnumerable<string> emails,
                                          LogReportSendOnly reportSendOnly,
                                          LogReportLogLevel reportLogLevel)
            => _client.Get<dynamic>("logs",
                                    "report_mail", string.Join(";", emails),
                                    "report_sendonly", reportSendOnly,
                                    "report_loglevel", reportLogLevel);
    }
}