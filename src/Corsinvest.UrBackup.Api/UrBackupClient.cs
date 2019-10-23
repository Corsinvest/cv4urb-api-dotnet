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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// UrBackup Client
    /// </summary>
    public class UrBackupClient
    {
        private readonly string _url;
        private string _session = "";
        private Backups _backups;
        private Settings _settings;
        private Status _status;
        private Usage _usage;
        private Logs _logs;

        private enum MethodType
        {
            Get,
            Post
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ssl"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public UrBackupClient(bool ssl, string host, int port)
            => _url = $"http{(ssl ? "s" : "")}://{host}:{port}/x";

        private byte[] CalculateMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        private static string BinaryToHex(byte[] value)
            => BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();


        private static byte[] PBKDF2Sha256GetBytes(int dklen, byte[] password, byte[] salt, int iterationCount)
        {
            using (var hmac = new HMACSHA256(password))
            {
                int hashLength = hmac.HashSize / 8;
                if ((hmac.HashSize & 7) != 0) { hashLength++; }

                int keyLength = dklen / hashLength;
                if ((long)dklen > (0xFFFFFFFFL * hashLength) || dklen < 0)
                {
                    throw new ArgumentOutOfRangeException("dklen");
                }

                if (dklen % hashLength != 0) { keyLength++; }

                var extendedkey = new byte[salt.Length + 4];
                Buffer.BlockCopy(salt, 0, extendedkey, 0, salt.Length);
                using (var ms = new MemoryStream())
                {
                    for (int i = 0; i < keyLength; i++)
                    {
                        extendedkey[salt.Length] = (byte)(((i + 1) >> 24) & 0xFF);
                        extendedkey[salt.Length + 1] = (byte)(((i + 1) >> 16) & 0xFF);
                        extendedkey[salt.Length + 2] = (byte)(((i + 1) >> 8) & 0xFF);
                        extendedkey[salt.Length + 3] = (byte)(((i + 1)) & 0xFF);
                        byte[] u = hmac.ComputeHash(extendedkey);
                        Array.Clear(extendedkey, salt.Length, 4);
                        byte[] f = u;
                        for (int j = 1; j < iterationCount; j++)
                        {
                            u = hmac.ComputeHash(u);
                            for (int k = 0; k < f.Length; k++)
                            {
                                f[k] ^= u[k];
                            }
                        }
                        ms.Write(f, 0, f.Length);
                        Array.Clear(u, 0, u.Length);
                        Array.Clear(f, 0, f.Length);
                    }
                    var dk = new byte[dklen];
                    ms.Position = 0;
                    ms.Read(dk, 0, dklen);
                    ms.Position = 0;
                    for (long i = 0; i < ms.Length; i++)
                    {
                        ms.WriteByte(0);
                    }
                    Array.Clear(extendedkey, 0, extendedkey.Length);
                    return dk;
                }
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            Console.Out.WriteLine("Trying anonymous login...");

            var login = Get("login");
            if (login.PropertyExists("success") && !login.Response.success)
            {
                Console.Out.WriteLine("Logging in...");

                var salt = Get("salt", "username", username);
                if (salt.PropertyExists("ses"))
                {
                    _session = salt.Response.ses;

                    if (salt.PropertyExists("salt"))
                    {
                        var passwordMD5Bin = CalculateMD5(salt.Response.salt + password) as byte[];
                        var passwordMD5 = BinaryToHex(passwordMD5Bin);

                        if (salt.PropertyExists("pbkdf2_rounds") && salt.Response.pbkdf2_rounds > 0)
                        {
                            //Dotnet Core 3 Work this
                            //using var pbkdf2 = new Rfc2898DeriveBytes(passwordMD5Bin,
                            //                                          Encoding.Default.GetBytes(salt.Data.salt) as byte[],
                            //                                          (int)salt.Data.pbkdf2_rounds,
                            //                                          HashAlgorithmName.SHA256);
                            //passwordMD5 = BinaryToHex(pbkdf2.GetBytes(32));
                            var pbkdf2 = PBKDF2Sha256GetBytes(32,
                                                              passwordMD5Bin,
                                                              Encoding.Default.GetBytes(salt.Response.salt) as byte[],
                                                              (int)salt.Response.pbkdf2_rounds);
                            passwordMD5 = BinaryToHex(pbkdf2);
                        }

                        passwordMD5 = BinaryToHex(CalculateMD5(salt.Response.rnd + passwordMD5));

                        login = Get("login",
                                    "username", username,
                                    "password", passwordMD5);

                        if (!login.PropertyExists("success") ||
                            (login.PropertyExists("success") && !login.Response.success))
                        {
                            Console.Out.WriteLine("Error during login. Password wrong?");
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        _session = login.Response.session;
                        return true;
                    }
                }
                else
                {
                    Console.Out.WriteLine("Username does not exist");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private Result<T> Execute<T>(string action,
                                     MethodType method,
                                     IDictionary<string, object> parameters = null)
            => new Result<T>(action, parameters, Request(action, method, parameters));

        private HttpResponseMessage Request(string action,
                                            MethodType method,
                                            IDictionary<string, object> parameters = null)
        {
            using (var handler = new HttpClientHandler()
            {
                CookieContainer = new CookieContainer(),
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            })
            using (var client = new HttpClient(handler))
            {
                client.Timeout = new TimeSpan(0, 10, 0);
                var url = _url + "?a=" + HttpUtility.UrlEncode(action);

                //load parameters
                var @params = new Dictionary<string, string>();
                if (parameters != null)
                {
                    @params = parameters.Where(a => a.Value != null)
                                        .ToDictionary(a => a.Key, a => a.Value + "");
                }

                if (_session.Length > 0) { @params.Add("ses", _session); }

                if (method == MethodType.Get && @params.Count > 0)
                {
                    url += "&" + string.Join("&", @params.Select(a => $"{a.Key}={HttpUtility.UrlEncode(a.Value)}"));
                }

                var httpMethod = HttpMethod.Post;
                switch (method)
                {
                    case MethodType.Get: httpMethod = HttpMethod.Get; break;
                    case MethodType.Post: httpMethod = HttpMethod.Post; break;
                }

                var request = new HttpRequestMessage(httpMethod, new Uri(url));
                request.Headers.Add("Accept", "application/json");
                //request.Headers.Add("Content-Type", "application/json; charset=UTF-8");

                if (method == MethodType.Post) { request.Content = new FormUrlEncodedContent(@params); }

                return client.SendAsync(request).Result;
            };
        }

        /// <summary>
        /// Get result
        /// </summary>
        /// <param name="action"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Result<dynamic> Get(string action, IDictionary<string, object> parameters = null)
            => Get<dynamic>(action, parameters);

        /// <summary>
        /// Get result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Result<T> Get<T>(string action, IDictionary<string, object> parameters = null)
            => Execute<T>(action, MethodType.Post, parameters);

        /// <summary>
        /// Get result
        /// </summary>
        /// <param name="action"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Result<dynamic> Get(string action, params object[] keyValue)
            => Get<dynamic>(action, keyValue);

        /// <summary>
        /// Get result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Result<T> Get<T>(string action, params object[] keyValue)
            => Get<T>(action, CreateParameters(keyValue));

        /// <summary>
        /// Create parameters
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Dictionary<string, object> CreateParameters(params object[] keyValue)
        {
            if (keyValue.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException("Parameters length not valid!");
            }

            var @params = new Dictionary<string, object>();
            for (int i = 0; i < keyValue.Length / 2; i++)
            {
                @params.Add(keyValue[0 + i * 2] + "", keyValue[1 + i * 2]);
            }

            return @params;
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="action"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public bool DownloadFile(string destination, string action, params object[] keyValue)
            => DownloadFile(destination, action, CreateParameters(keyValue));

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="action"></param>
        /// <param name="parameters"></param>
        public bool DownloadFile(string destination,
                                 string action,
                                 IDictionary<string, object> parameters = null)
        {
            var response = Request(action, MethodType.Get, parameters);
            if (response.StatusCode != HttpStatusCode.OK) { return false; }

            using (var fs = new FileStream(destination,
                                           FileMode.Create,
                                           FileAccess.Write,
                                           FileShare.None))
            {
                response.Content.CopyToAsync(fs);
            }

            return true;
        }

        /// <summary>
        /// Get client name from id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public string GetClientName(int clientId)
            => Settings.GetGeneral().Get().Response.Navitems.Clients
                       .Where(a => a.Id == clientId)
                       .Select(a => a.Name)
                       .FirstOrDefault();

        /// <summary>
        /// Get client id from name
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public long GetClientId(string clientName)
            => Settings.GetGeneral().Get().Response.Navitems.Clients
               .Where(a => a.Name == clientName)
               .Select(a => a.Id)
               .DefaultIfEmpty(-1)
               .FirstOrDefault();

        /// <summary>
        /// Backups
        /// </summary>
        public Backups Backups => _backups ?? (_backups = new Backups(this));

        /// <summary>
        /// Settings
        /// </summary>
        public Settings Settings => _settings ?? (_settings = new Settings(this));

        /// <summary>
        /// Status
        /// </summary>
        public Status Status => _status ?? (_status = new Status(this));

        /// <summary>
        /// usage
        /// </summary>
        public Usage Usage => _usage ?? (_usage = new Usage(this));

        /// <summary>
        /// Logs
        /// </summary>
        public Logs Logs => _logs ?? (_logs = new Logs(this));

        /// <summary>
        /// Get User 
        /// </summary>
        /// <returns></returns>
        public Result<UserResult> GetUsers() => Get<UserResult>("users");

        /// <summary>
        /// Get actions
        /// </summary>
        /// <returns></returns>
        public Result<ActionResult> GetActions() => Get<ActionResult>("progress");

        /// <summary>
        /// Stop action
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public Result<dynamic> StopAction(long clientId, long actionId)
            => Get("progress",
                   "stop_clientid", clientId,
                   "stop_id", actionId);


        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public Result<dynamic> AddClient(string clientName)
            => Get("add_client", "clientname", clientName);

        /// <summary>
        /// Make file name client installer
        /// </summary>
        /// <param name="os"></param>
        /// <param name="newClientName"></param>
        /// <returns></returns>
        public static string MakeFileNameClientInstaller(OperationSystem os, string newClientName)
        {
            var ext = "";
            switch (os)
            {
                case OperationSystem.Windows: ext = "exe"; break;
                case OperationSystem.MacOSX: ext = "sh"; break;
                case OperationSystem.Linux: ext = "sh"; break;
            }

            return $"UrBackup Client ({newClientName}).{ext}";
        }

        /// <summary>
        /// Download installer
        /// </summary>
        /// <param name="os"></param>
        /// <param name="newClientName"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool DownloadInstaller(OperationSystem os, string newClientName, string destination)
        {
            var osType = "";
            switch (os)
            {
                case OperationSystem.Windows: osType = "windows"; break;
                case OperationSystem.MacOSX: osType = "mac"; break;
                case OperationSystem.Linux: osType = "linux"; break;
            }

            var ret = Get("add_client", "clientname", newClientName);
            if (ret.PropertyExists("already_exists"))
            {
                var client = Status.GetClient(newClientName);
                if (client == null) { return false; }

                return DownloadFile(destination,
                                    "download_client",
                                    CreateParameters("clientid", client.Id,
                                                     "os", osType));
            }

            if (!ret.PropertyExists("new_authkey")) { return false; }

            return DownloadFile(destination,
                                "download_client",
                                CreateParameters("clientid", ret.Response.new_clientid,
                                                 "authkey", ret.Response.new_authkey,
                                                 "os", osType));
        }

        /// <summary>
        /// Shutdown
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> Shutdown() => Get("shutdown");
    }
}