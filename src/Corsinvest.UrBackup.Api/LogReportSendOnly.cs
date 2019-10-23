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

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Report Send Only 
    /// </summary>
    public enum LogReportSendOnly
        {
            /// <summary>
            /// All
            /// </summary>
            All = 0,

            /// <summary>
            /// Failed
            /// </summary>
            Failed = 1,

            /// <summary>
            /// Successfull
            /// </summary>
            Successfull = 2,

            /// <summary>
            /// Failed without failures caused by client timeout
            /// </summary>
            FailedWithoutFailuresCausedByClientTimeout = 3
        }
}