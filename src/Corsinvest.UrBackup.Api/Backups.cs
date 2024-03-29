﻿/*
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
    /// Backups
    /// </summary>
    public class Backups
    {
        private readonly UrBackupClient _client;

        internal Backups(UrBackupClient client) => _client = client;

        /// <summary>
        /// Start backup
        /// </summary>
        /// <param name="clientsId"></param>
        /// <param name="backupType"></param>
        /// <returns></returns>
        public Result<dynamic> Start(IEnumerable<long> clientsId, BackupType backupType)
        {
            var startType = "";
            switch (backupType)
            {
                case BackupType.IncrementalFile: startType = "incr_file"; break;
                case BackupType.FullFile: startType = "full_file"; break;
                case BackupType.IncrementalImage: startType = "incr_image"; break;
                case BackupType.FullImage: startType = "full_image"; break;
            }

            return _client.Get("start_backup",
                               "start_client", string.Join(",", clientsId.Select(a => a + "")),
                               "start_type", startType);
        }

        /// <summary>
        /// Get last backup
        /// </summary>
        /// <returns></returns>
        public Result<BackupClientResult> Get()
            => _client.Get<BackupClientResult>("backups");

        /// <summary>
        /// Get client backups
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Result<BackupResult> Get(long clientId)
            => _client.Get<BackupResult>("backups",
                                         "sa", "backups",
                                         "clientid", clientId);

        /// <summary>
        /// Get backup files
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="backupId"></param>
        /// <param name="path"></param>
        /// <param name="mount"></param>
        /// <returns></returns>
        public Result<BackupFileResult> GetBackupFiles(long clientId,
                                                       long backupId,
                                                       string path = "",
                                                       bool mount = false)
            => _client.Get<BackupFileResult>("backups",
                                             "sa", "files",
                                             "clientid", clientId,
                                             "backupid", backupId,
                                             "path", path,
                                             "mount", mount ? "1" : "0");

        /// <summary>
        /// Download backup file
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="clientId"></param>
        /// <param name="backupId"></param>
        /// <param name="path"></param>
        /// <param name="zipped"></param>
        /// <returns></returns>
        public bool DownloadBackupFile(string destination,
                                       long clientId,
                                       long backupId,
                                       string path,
                                       bool zipped = false)
            => _client.DownloadFile(destination, "backups",
                                    new Dictionary<string, object>()
                                    {
                                        { "sa", zipped  ?"zipdl": "filesdl" },
                                        { "clientid", clientId },
                                        { "backupid", backupId },
                                        { "path", path },
                                    });

        /// <summary>
        /// Backup acton
        /// </summary>
        /// <param name="backupAction"></param>
        /// <param name="clientId"></param>
        /// <param name="backupId"></param>
        /// <returns></returns>
        public Result<dynamic> Action(BackupAction backupAction, long clientId, long backupId)
        {
            var action = "";
            switch (backupAction)
            {
                case BackupAction.Archive: action = "archive"; break;
                case BackupAction.UnArchive: action = "unarchive"; break;
                case BackupAction.Delete: action = "delete"; break;
                case BackupAction.StopDelete: action = "stop_delete"; break;
                case BackupAction.DeleteNow: action = "delete_now"; break;
            }

            return _client.Get("backups",
                               "sa", "backups",
                               "clientid", clientId,
                               action, backupId);
        }


        //new getJSON("backups", "sa=files&clientid="+clientid+"&path="+path.replace(/\//g,"%2F")+"&is_file=false", show_backups2);
        //	new getJSON("backups", "sa=files&clientid="+clientid+"&path="+path.replace(/\//g,"%2F")+"&is_file=true", show_backups2);


        //restore
        //	new getJSON("backups", "sa=clientdl&clientid="+clientid+"&backupid="+backupid+"&path="+path.replace(/\//g,"%2F")+filter, restore_callback);
    }
}