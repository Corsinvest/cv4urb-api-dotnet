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
    /// Action type
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Incremental File 
        /// </summary>
        IncrementalFile = 1,

        /// <summary>
        /// Full File 
        /// </summary>
        FullFile = 2,

        /// <summary>
        /// Incremental Image 
        /// </summary>
        IncrementalImage = 3,

        /// <summary>
        /// Full Image 
        /// </summary>
        FullImage = 4,

        /// <summary>
        /// Resumed Incremental File 
        /// </summary>
        ResumedIncrementalFile = 5,

        /// <summary>
        /// Resumed Full File 
        /// </summary>
        ResumedFullFile = 6,

        /// <summary>
        /// File Restore
        /// </summary>
        FileRestore = 8,

        /// <summary>
        /// Image Restore
        /// </summary>
        ImageRestore = 9,

        /// <summary>
        /// Client Update
        /// </summary>
        ClientUpdate = 10,

        /// <summary>
        /// Check Db Integrity
        /// </summary>
        CheckDbIntegrity = 11,

        /// <summary>
        /// Backup Db
        /// </summary>
        BackupDb = 12,

        /// <summary>
        /// Recalc Stats
        /// </summary>
        RecalcStats = 13
    }
}
