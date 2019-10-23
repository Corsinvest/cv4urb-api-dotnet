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
using System.Linq;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Status
    /// </summary>
    public class Status
    {
        private readonly UrBackupClient _client;

        internal Status(UrBackupClient client) => _client = client;

        /// <summary>
        /// Get status
        /// </summary>
        /// <returns></returns>
        public Result<StatusResult> Get() => _client.Get<StatusResult>("status");

        /// <summary>
        /// Get client status
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public StatusResult.StatusClient GetClient(long clientId)
            => Get().Response.Status.Where(a => a.Id == clientId).FirstOrDefault();

        /// <summary>
        /// Get client status
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public StatusResult.StatusClient GetClient(string clientName)
            => Get().Response.Status.Where(a => a.Name == clientName).FirstOrDefault();

        /// <summary>
        /// Add hostname
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public Result<dynamic> AddHostname(string hostname) => _client.Get("status", "hostname", hostname);

        /// <summary>
        /// Remove hostname
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public Result<dynamic> RemoveHostname(string hostname)
            => _client.Get("status", "hostname", hostname, "remove", true);

        /// <summary>
        /// Add internet client
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public Result<dynamic> AddInternetClient(string hostname) => _client.Get("status", "clientname", hostname);

        /// <summary>
        /// Stop show
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> StopSHow() => _client.Get("status", "stop_show", true);

        /// <summary>
        /// Remove clients
        /// </summary>
        /// <param name="clientsId"></param>
        /// <returns></returns>
        public Result<dynamic> RemoveClient(IEnumerable<long> clientsId)
            => _client.Get("status", "remove_client", string.Join(",", clientsId.Select(a => a + "")));

        /// <summary>
        /// Stop Remove clients
        /// </summary>
        /// <param name="clientsId"></param>
        /// <returns></returns>
        public Result<dynamic> StopRemoveClient(IEnumerable<long> clientsId)
            => _client.Get("status",
                           "stop_remove_client", true,
                           "remove_client", string.Join(",", clientsId.Select(a => a + "")));

        /// <summary>
        /// Reset Error Type 
        /// </summary>
        public enum ResetErrorType
        {
            /// <summary>
            /// nospc_stalled
            /// </summary>
            NospcStalled,

            /// <summary>
            /// nospc_fatal
            /// </summary>
            NospcFatal,

            /// <summary>
            /// database_error
            /// </summary>
            DatabaseError
        }

        /// <summary>
        /// Reset error
        /// </summary>
        /// <param name="errorType"></param>
        /// <returns></returns>
        public Result<dynamic> ResetError(ResetErrorType errorType)
        {
            var errorReset = "";
            switch (errorType)
            {
                case ResetErrorType.NospcStalled: errorReset = "nospc_stalled"; break;
                case ResetErrorType.NospcFatal: errorReset = "nospc_fatal"; break;
                case ResetErrorType.DatabaseError: errorReset = "database_error"; break;
            }

            return _client.Get("status", "reset_error", errorReset);
        }

        /// <summary>
        /// Stop show
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> StopShowVersion() => _client.Get("status", "stop_show_version", true);
    }
}