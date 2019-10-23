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

using Newtonsoft.Json;

namespace Corsinvest.UrBackup.Api.Results
{
    public class SettingsGroupResult
    {
        [JsonProperty("ONLY_WIN32_BEGIN")]
        public string OnlyWin32Begin { get; set; }

        [JsonProperty("ONLY_WIN32_END")]
        public string OnlyWin32End { get; set; }

        [JsonProperty("archive_settings")]
        public object[] ArchiveSettings { get; set; }

        [JsonProperty("cowraw_available")]
        public bool CowrawAvailable { get; set; }

        [JsonProperty("navitems")]
        public NavitemsSettings Navitems { get; set; }

        [JsonProperty("sa")]
        public string Sa { get; set; }

        [JsonProperty("settings")]
        public SettingsSettings Settings { get; set; }

        public class NavitemsSettings
        {
            [JsonProperty("clients")]
            public Client[] Clients { get; set; }

            [JsonProperty("disable_change_pw")]
            public bool DisableChangePw { get; set; }

            [JsonProperty("general")]
            public bool General { get; set; }

            [JsonProperty("groupmod")]
            public bool Groupmod { get; set; }

            [JsonProperty("groups")]
            public Group[] Groups { get; set; }

            [JsonProperty("internet")]
            public bool Internet { get; set; }

            [JsonProperty("ldap")]
            public bool Ldap { get; set; }

            [JsonProperty("mail")]
            public bool Mail { get; set; }

            [JsonProperty("users")]
            public bool Users { get; set; }
        }

        public class Client
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

        public class Group
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class SettingsSettings
        {
            [JsonProperty("alert_params")]
            public string AlertParams { get; set; }

            [JsonProperty("alert_script")]
            public long AlertScript { get; set; }

            [JsonProperty("alert_scripts")]
            public AlertScript[] AlertScripts { get; set; }

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

            [JsonProperty("background_backups")]
            public bool BackgroundBackups { get; set; }

            [JsonProperty("backup_window_full_file")]
            public string BackupWindowFullFile { get; set; }

            [JsonProperty("backup_window_full_image")]
            public string BackupWindowFullImage { get; set; }

            [JsonProperty("backup_window_incr_file")]
            public string BackupWindowIncrFile { get; set; }

            [JsonProperty("backup_window_incr_image")]
            public string BackupWindowIncrImage { get; set; }

            [JsonProperty("can_edit_scripts")]
            public bool CanEditScripts { get; set; }

            [JsonProperty("cbt_crash_persistent_volumes")]
            public string CbtCrashPersistentVolumes { get; set; }

            [JsonProperty("cbt_volumes")]
            public string CbtVolumes { get; set; }

            [JsonProperty("client_quota")]
            public string ClientQuota { get; set; }

            [JsonProperty("client_set_settings")]
            public bool ClientSetSettings { get; set; }

            [JsonProperty("clientid")]
            public long Clientid { get; set; }

            [JsonProperty("computername")]
            public string Computername { get; set; }

            [JsonProperty("create_linked_user_views")]
            public bool CreateLinkedUserViews { get; set; }

            [JsonProperty("default_dirs")]
            public string DefaultDirs { get; set; }

            [JsonProperty("end_to_end_file_backup_verification")]
            public bool EndToEndFileBackupVerification { get; set; }

            [JsonProperty("exclude_files")]
            public string ExcludeFiles { get; set; }

            [JsonProperty("file_snapshot_groups")]
            public string FileSnapshotGroups { get; set; }

            [JsonProperty("groupid")]
            public long Groupid { get; set; }

            [JsonProperty("groupname")]
            public string Groupname { get; set; }

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

            [JsonProperty("min_file_full")]
            public long MinFileFull { get; set; }

            [JsonProperty("min_file_incr")]
            public long MinFileIncr { get; set; }

            [JsonProperty("min_image_full")]
            public long MinImageFull { get; set; }

            [JsonProperty("min_image_incr")]
            public long MinImageIncr { get; set; }

            [JsonProperty("overwrite")]
            public bool Overwrite { get; set; }

            [JsonProperty("silent_update")]
            public bool SilentUpdate { get; set; }

            [JsonProperty("startup_backup_delay")]
            public long StartupBackupDelay { get; set; }

            [JsonProperty("update_freq_full")]
            public long UpdateFreqFull { get; set; }

            [JsonProperty("update_freq_image_full")]
            public long UpdateFreqImageFull { get; set; }

            [JsonProperty("update_freq_image_incr")]
            public long UpdateFreqImageIncr { get; set; }

            [JsonProperty("update_freq_incr")]
            public long UpdateFreqIncr { get; set; }

            [JsonProperty("verify_using_client_hashes")]
            public bool VerifyUsingClientHashes { get; set; }

            [JsonProperty("virtual_clients")]
            public string VirtualClients { get; set; }

            [JsonProperty("vss_select_components")]
            public string VssSelectComponents { get; set; }
        }

        public class AlertScript
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("params")]
            public Param[] Params { get; set; }
        }

        public class Param
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