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

using Corsinvest.UrBackup.Api.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;

namespace Corsinvest.UrBackup.Api
{
    /// <summary>
    /// Result request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        internal Result(string action,
                        IDictionary<string, object> parameters,
                        HttpResponseMessage response)
        {
            Action = action;
            Parameters = parameters;
            IsSuccessStatusCode = response.IsSuccessStatusCode;
            ReasonPhrase = response.ReasonPhrase;
            StatusCode = response.StatusCode;

            OriginalResult = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (typeof(T) == typeof(object))
                {
                    //if dynamic create ExpandoObject
                    Response = (dynamic)JsonConvert.DeserializeObject<ExpandoObject>(OriginalResult);
                }
                else
                {
                    Response = JsonConvert.DeserializeObject<T>(OriginalResult);
                }
            }
        }

        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; }

        /// <summary>
        /// Parameters
        /// </summary>
        public IDictionary<string, object> Parameters { get; }

        /// <summary>
        /// Success code
        /// </summary>
        public bool IsSuccessStatusCode { get; }

        /// <summary>
        /// Reason Phrase
        /// </summary>
        public string ReasonPhrase { get; }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Json result
        /// </summary>
        public string OriginalResult { get; }

        /// <summary>
        /// Data result converted
        /// </summary>
        public T Response { get; }

        /// <summary>
        /// Property exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool PropertyExists(string name) => ObjectHelper.PropertyExists(Response, name);
    }
}