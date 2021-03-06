﻿using System.Net.Http;
using System.Threading.Tasks;
using Aptacode.CSharp.Common.Http.Interfaces;
using Aptacode.CSharp.Common.Http.Services.Responses;

namespace Aptacode.CSharp.Common.Http.Services
{
    /// <summary>
    ///     HttpServiceClient using C#'s HttpClient
    /// </summary>
    public class HttpServiceClient : IHttpServiceClient
    {
        protected readonly IHttpClient HttpClient;
        protected readonly IHttpRequestGenerator RequestGenerator;

        public HttpServiceClient(IHttpClient client, IHttpRequestGenerator requestGenerator)
        {
            HttpClient = client;
            RequestGenerator = requestGenerator;
        }

        public async Task<HttpServiceResponse<TReturn>> Send<TReturn, TSend>(HttpMethod method, string route,
            TSend content)
        {
            var requestMessage = RequestGenerator.CreateRequest(method, route, content);
            if (requestMessage == null)
            {
                return HttpServiceResponse<TReturn>.Create("Could not create request");
            }

            return await HttpClient.Send<TReturn>(requestMessage).ConfigureAwait(false);
        }

        public async Task<HttpServiceResponse<TReturn>> Send<TReturn>(HttpMethod method,
            string route)
        {
            var requestMessage = RequestGenerator.CreateRequest(method, route);
            if (requestMessage == null)
            {
                return HttpServiceResponse<TReturn>.Create("Could not create request");
            }

            return await HttpClient.Send<TReturn>(requestMessage).ConfigureAwait(false);
        }
    }
}