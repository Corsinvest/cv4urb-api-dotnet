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
using System.Collections.Generic;

namespace Corsinvest.UrBackup.Api.Results
{
    public partial class SettingsGeneralResult : BaseResult
    {
        [JsonProperty("ONLY_WIN32_BEGIN")]
        public string OnlyWin32Begin { get; set; }

        [JsonProperty("ONLY_WIN32_END")]
        public string OnlyWin32End { get; set; }

        [JsonProperty("archive_settings")]
        public List<object> ArchiveSettings { get; set; }

        [JsonProperty("cowraw_available")]
        public bool CowrawAvailable { get; set; }

        [JsonProperty("navitems")]
        public NavitemsSettings Navitems { get; set; }

        [JsonProperty("sa")]
        public string Sa { get; set; }

        [JsonProperty("settings")]
        public SettingsSettings Settings { get; set; }

        public partial class NavitemsSettings
        {
            [JsonProperty("clients")]
            public List<Client> Clients { get; set; }

            [JsonProperty("disable_change_pw")]
            public bool DisableChangePw { get; set; }

            [JsonProperty("general")]
            public bool General { get; set; }

            [JsonProperty("groupmod")]
            public bool Groupmod { get; set; }

            [JsonProperty("groups")]
            public List<Group> Groups { get; set; }

            [JsonProperty("internet")]
            public bool Internet { get; set; }

            [JsonProperty("ldap")]
            public bool Ldap { get; set; }

            [JsonProperty("mail")]
            public bool Mail { get; set; }

            [JsonProperty("users")]
            public bool Users { get; set; }
        }

        public partial class Client
        {
            [JsonProperty("group")]
            public long Group { get; set; }

            [JsonProperty("groupname")]
            public string Groupname { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("override")]
            public bool Override { get; set; }
        }

        public partial class Group
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class SettingsSettings
        {
            [JsonProperty("ONLY_WIN32_BEGIN")]
            public string OnlyWin32Begin { get; set; }

            [JsonProperty("ONLY_WIN32_END")]
            public string OnlyWin32End { get; set; }

            [JsonProperty("alert_params")]
            public string AlertParams { get; set; }

            [JsonProperty("alert_script")]
            public long AlertScript { get; set; }

            [JsonProperty("alert_scripts")]
            public List<AlertScript> AlertScripts { get; set; }

            [JsonProperty("allow_component_config")]
            public bool AllowComponentConfig { get; set; }

            [JsonProperty("allow_component_restore")]
            public bool AllowComponentRestore { get; set; }

            [JsonProperty("allow_config_paths")]
            public bool AllowConfigPaths { get; set; }

            [JsonProperty("allow_file_restore")]
            public bool AllowFileRestore { get; set; }

            [JsonProperty("allow_log_view")]
            public bool AllowLogView { get; set; }

            [JsonProperty("allow_overwrite")]
            public bool AllowOverwrite { get; set; }

            [JsonProperty("allow_pause")]
            public bool AllowPause { get; set; }

            [JsonProperty("allow_starting_full_file_backups")]
            public bool AllowStartingFullFileBackups { get; set; }

            [JsonProperty("allow_starting_full_image_backups")]
            public bool AllowStartingFullImageBackups { get; set; }

            [JsonProperty("allow_starting_incr_file_backups")]
            public bool AllowStartingIncrFileBackups { get; set; }

            [JsonProperty("allow_starting_incr_image_backups")]
            public bool AllowStartingIncrImageBackups { get; set; }

            [JsonProperty("allow_tray_exit")]
            public bool AllowTrayExit { get; set; }

            [JsonProperty("autoshutdown")]
            public bool Autoshutdown { get; set; }

            [JsonProperty("autoupdate_clients")]
            public bool AutoupdateClients { get; set; }

            [JsonProperty("background_backups")]
            public bool BackgroundBackups { get; set; }

            [JsonProperty("backup_database")]
            public bool BackupDatabase { get; set; }

            [JsonProperty("backup_window_full_file")]
            public string BackupWindowFullFile { get; set; }

            [JsonProperty("backup_window_full_image")]
            public string BackupWindowFullImage { get; set; }

            [JsonProperty("backup_window_incr_file")]
            public string BackupWindowIncrFile { get; set; }

            [JsonProperty("backup_window_incr_image")]
            public string BackupWindowIncrImage { get; set; }

            [JsonProperty("backupfolder")]
            public string Backupfolder { get; set; }

            [JsonProperty("can_edit_scripts")]
            public bool CanEditScripts { get; set; }

            [JsonProperty("cbt_crash_persistent_volumes")]
            public string CbtCrashPersistentVolumes { get; set; }

            [JsonProperty("cbt_volumes")]
            public string CbtVolumes { get; set; }

            [JsonProperty("cleanup_window")]
            public string CleanupWindow { get; set; }

            [JsonProperty("client_quota")]
            public string ClientQuota { get; set; }

            [JsonProperty("client_set_settings")]
            public bool ClientSetSettings { get; set; }

            [JsonProperty("computername")]
            public string Computername { get; set; }

            [JsonProperty("create_linked_user_views")]
            public bool CreateLinkedUserViews { get; set; }

            [JsonProperty("default_dirs")]
            public string DefaultDirs { get; set; }

            [JsonProperty("download_client")]
            public bool DownloadClient { get; set; }

            [JsonProperty("end_to_end_file_backup_verification")]
            public bool EndToEndFileBackupVerification { get; set; }

            [JsonProperty("exclude_files")]
            public string ExcludeFiles { get; set; }

            [JsonProperty("file_snapshot_groups")]
            public string FileSnapshotGroups { get; set; }

            [JsonProperty("global_internet_speed")]
            public long GlobalInternetSpeed { get; set; }

            [JsonProperty("global_local_speed")]
            public long GlobalLocalSpeed { get; set; }

            [JsonProperty("global_soft_fs_quota")]
            public string GlobalSoftFsQuota { get; set; }

            [JsonProperty("ignore_disk_errors")]
            public bool IgnoreDiskErrors { get; set; }

            [JsonProperty("image_file_format")]
            public string ImageFileFormat { get; set; }

            [JsonProperty("image_letters")]
            public string ImageLetters { get; set; }

            [JsonProperty("image_snapshot_groups")]
            public string ImageSnapshotGroups { get; set; }

            [JsonProperty("include_files")]
            public string IncludeFiles { get; set; }

            [JsonProperty("internet_authkey")]
            public string InternetAuthkey { get; set; }

            [JsonProperty("internet_calculate_filehashes_on_client")]
            public bool InternetCalculateFilehashesOnClient { get; set; }

            [JsonProperty("internet_compress")]
            public bool InternetCompress { get; set; }

            [JsonProperty("internet_connect_always")]
            public bool InternetConnectAlways { get; set; }

            [JsonProperty("internet_encrypt")]
            public bool InternetEncrypt { get; set; }

            [JsonProperty("internet_file_dataplan_limit")]
            public long InternetFileDataplanLimit { get; set; }

            [JsonProperty("internet_full_file_backups")]
            public bool InternetFullFileBackups { get; set; }

            [JsonProperty("internet_full_file_transfer_mode")]
            public string InternetFullFileTransferMode { get; set; }

            [JsonProperty("internet_full_image_style")]
            public string InternetFullImageStyle { get; set; }

            [JsonProperty("internet_image_backups")]
            public bool InternetImageBackups { get; set; }

            [JsonProperty("internet_image_dataplan_limit")]
            public long InternetImageDataplanLimit { get; set; }

            [JsonProperty("internet_image_transfer_mode")]
            public string InternetImageTransferMode { get; set; }

            [JsonProperty("internet_incr_file_transfer_mode")]
            public string InternetIncrFileTransferMode { get; set; }

            [JsonProperty("internet_incr_image_style")]
            public string InternetIncrImageStyle { get; set; }

            [JsonProperty("internet_mode_enabled")]
            public bool InternetModeEnabled { get; set; }

            [JsonProperty("internet_parallel_file_hashing")]
            public bool InternetParallelFileHashing { get; set; }

            [JsonProperty("internet_readd_file_entries")]
            public bool InternetReaddFileEntries { get; set; }

            [JsonProperty("internet_server")]
            public string InternetServer { get; set; }

            [JsonProperty("internet_server_port")]
            public long InternetServerPort { get; set; }

            [JsonProperty("internet_speed")]
            public long InternetSpeed { get; set; }

            [JsonProperty("local_full_file_transfer_mode")]
            public string LocalFullFileTransferMode { get; set; }

            [JsonProperty("local_full_image_style")]
            public string LocalFullImageStyle { get; set; }

            [JsonProperty("local_image_transfer_mode")]
            public string LocalImageTransferMode { get; set; }

            [JsonProperty("local_incr_file_transfer_mode")]
            public string LocalIncrFileTransferMode { get; set; }

            [JsonProperty("local_incr_image_style")]
            public string LocalIncrImageStyle { get; set; }

            [JsonProperty("local_speed")]
            public long LocalSpeed { get; set; }

            [JsonProperty("max_active_clients")]
            public long MaxActiveClients { get; set; }

            [JsonProperty("max_file_full")]
            public long MaxFileFull { get; set; }

            [JsonProperty("max_file_incr")]
            public long MaxFileIncr { get; set; }

            [JsonProperty("max_image_full")]
            public long MaxImageFull { get; set; }

            [JsonProperty("max_image_incr")]
            public long MaxImageIncr { get; set; }

            [JsonProperty("max_running_jobs_per_client")]
            public long MaxRunningJobsPerClient { get; set; }

            [JsonProperty("max_sim_backups")]
            public long MaxSimBackups { get; set; }

            [JsonProperty("min_file_full")]
            public long MinFileFull { get; set; }

            [JsonProperty("min_file_incr")]
            public long MinFileIncr { get; set; }

            [JsonProperty("min_image_full")]
            public long MinImageFull { get; set; }

            [JsonProperty("min_image_incr")]
            public long MinImageIncr { get; set; }

            [JsonProperty("no_file_backups")]
            public bool NoFileBackups { get; set; }

            [JsonProperty("no_images")]
            public bool NoImages { get; set; }

            [JsonProperty("restore_authkey")]
            public string RestoreAuthkey { get; set; }

            [JsonProperty("server_url")]
            public string ServerUrl { get; set; }

            [JsonProperty("show_server_updates")]
            public bool ShowServerUpdates { get; set; }

            [JsonProperty("silent_update")]
            public bool SilentUpdate { get; set; }

            [JsonProperty("startup_backup_delay")]
            public long StartupBackupDelay { get; set; }

            [JsonProperty("tmpdir")]
            public string Tmpdir { get; set; }

            [JsonProperty("update_dataplan_db")]
            public bool UpdateDataplanDb { get; set; }

            [JsonProperty("update_freq_full")]
            public long UpdateFreqFull { get; set; }

            [JsonProperty("update_freq_image_full")]
            public long UpdateFreqImageFull { get; set; }

            [JsonProperty("update_freq_image_incr")]
            public long UpdateFreqImageIncr { get; set; }

            [JsonProperty("update_freq_incr")]
            public long UpdateFreqIncr { get; set; }

            [JsonProperty("update_stats_cachesize")]
            public long UpdateStatsCachesize { get; set; }

            [JsonProperty("use_incremental_symlinks")]
            public bool UseIncrementalSymlinks { get; set; }

            [JsonProperty("use_tmpfiles")]
            public bool UseTmpfiles { get; set; }

            [JsonProperty("use_tmpfiles_images")]
            public bool UseTmpfilesImages { get; set; }

            [JsonProperty("verify_using_client_hashes")]
            public bool VerifyUsingClientHashes { get; set; }

            [JsonProperty("virtual_clients")]
            public string VirtualClients { get; set; }

            [JsonProperty("vss_select_components")]
            public string VssSelectComponents { get; set; }
        }

        public partial class AlertScript
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("params")]
            public List<Param> Params { get; set; }
        }

        public partial class Param
        {
            [JsonProperty("default_value")]
            public string DefaultValue { get; set; }

            [JsonProperty("has_translation")]
            public long HasTranslation { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }
    }
}