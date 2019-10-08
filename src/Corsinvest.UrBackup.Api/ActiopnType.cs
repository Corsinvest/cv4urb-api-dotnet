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
