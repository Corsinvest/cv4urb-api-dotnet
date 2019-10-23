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