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
    /// <summary>
    /// Base result
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error")]
        public int Error { get; set; }
    }
}