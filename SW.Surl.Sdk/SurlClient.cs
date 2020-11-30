using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SW.HttpExtensions;
using SW.PrimitiveTypes;
using SW.Surl.Model;

namespace SW.Surl.Sdk
{
    public class SurlClient : ApiClientBase<SurlClientOptions>, ISurlClient
    {
        public SurlClient(HttpClient httpClient, RequestContext requestContext, SurlClientOptions options) : base(httpClient, requestContext, options) { }
        

        public async Task<ShortUrlInfo> CreateShortUrl(string url)
        {
            return await Builder
                .Path("l/")
                .As<ShortUrlInfo>()
                .PostAsync(new CreateShortUrl()
                {
                    FullUrl = url
                });
        }
    }
}