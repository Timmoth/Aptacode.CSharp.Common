﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Aptacode.CSharp.Common.Http.Services.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.CSharp.Common.Http.Services
{
    public static class HttpRequestBuilder
    {
        public static HttpRequestMessage SetMethod(this HttpRequestMessage requestMessage, HttpMethod method)
        {
            requestMessage.Method = method;
            return requestMessage;
        }

        public static HttpRequestMessage SetRoute(this HttpRequestMessage requestMessage, string endPoint)
        {
            requestMessage.RequestUri = new Uri(endPoint);
            return requestMessage;
        }

        public static HttpRequestMessage AddAuthentication(this HttpRequestMessage requestMessage,
            IAccessTokenService accessTokenService)
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", accessTokenService.AccessToken);
            return requestMessage;
        }

        public static HttpRequestMessage AddContent<TContent>(this HttpRequestMessage requestMessage, TContent content)
        {
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8,
                MimeTypes.MimeTypes.Application.Json.ToString());
            return requestMessage;
        }
    }
}