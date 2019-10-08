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

namespace Corsinvest.UrBackup.Api.Results
{
    public partial class StatusResult : BaseResult
    {
        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("allow_add_client")]
        public bool AllowAddClient { get; set; }

        [JsonProperty("allow_extra_clients")]
        public bool AllowExtraClients { get; set; }

        [JsonProperty("allow_modify_clients")]
        public bool AllowModifyClients { get; set; }

        [JsonProperty("client_downloads")]
        public ClientDownload[] ClientDownloads { get; set; }

        [JsonProperty("curr_version_num")]
        public long CurrVersionNum { get; set; }

        [JsonProperty("curr_version_str")]
        public string CurrVersionStr { get; set; }

        [JsonProperty("extra_clients")]
        public object[] ExtraClients { get; set; }

        [JsonProperty("has_status_check")]
        public bool HasStatusCheck { get; set; }

        [JsonProperty("no_file_backups")]
        public bool NoFileBackups { get; set; }

        [JsonProperty("no_images")]
        public bool NoImages { get; set; }

        [JsonProperty("remove_client")]
        public bool RemoveClient { get; set; }

        [JsonProperty("server_identity")]
        public string ServerIdentity { get; set; }

        [JsonProperty("status")]
        public StatusClient[] Status { get; set; }

        public partial class ClientDownload
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class StatusClient
        {
            [JsonProperty("client_version_string")]
            public string ClientVersionString { get; set; }

            [JsonProperty("delete_pending")]
            public string DeletePending { get; set; }

            [JsonProperty("file_ok")]
            public bool FileOk { get; set; }

            [JsonProperty("groupname")]
            public string Groupname { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("image_ok")]
            public bool ImageOk { get; set; }

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("last_filebackup_issues")]
            public long LastFilebackupIssues { get; set; }

            [JsonProperty("lastbackup")]
            public long Lastbackup { get; set; }

            [JsonProperty("lastbackup_image")]
            public long LastbackupImage { get; set; }

            [JsonProperty("lastseen")]
            public long Lastseen { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("online")]
            public bool Online { get; set; }

            [JsonProperty("os_simple")]
            public string OsSimple { get; set; }

            [JsonProperty("os_version_string")]
            public string OsVersionString { get; set; }

            [JsonProperty("processes")]
            public Process[] Processes { get; set; }

            [JsonProperty("status")]
            public long StatusStatus { get; set; }

            [JsonProperty("no_backup_paths", NullValueHandling = NullValueHandling.Ignore)]
            public bool? NoBackupPaths { get; set; }
        }

        public partial class Process
        {
            [JsonProperty("action")]
            public long Action { get; set; }

            [JsonProperty("pcdone")]
            public long Pcdone { get; set; }
        }
    }
}
