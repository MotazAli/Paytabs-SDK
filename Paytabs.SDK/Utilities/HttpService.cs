// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Paytabs.SDK.Utilities
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Call(HttpMethod method, string uri, object content, string authorization = null , CancellationToken cancellationToken = default)
        {

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var jsonString = JsonSerializer.Serialize(content, jsonSerializerOptions);

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            HttpRequestHeaders headers = httpRequestMessage.Headers;
            headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            headers.Add(HttpRequestHeader.ContentType.ToString(), "application/json");

            if (authorization != null && authorization.Length > 0)
                headers.Add(HttpRequestHeader.Authorization.ToString(), authorization);

            return await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
        }
    }
}
