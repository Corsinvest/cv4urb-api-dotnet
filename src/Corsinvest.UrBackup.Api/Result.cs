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