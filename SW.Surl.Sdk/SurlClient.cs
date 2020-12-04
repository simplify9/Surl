using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SW.HttpExtensions;
using SW.PrimitiveTypes;
using SW.Surl.Model;

namespace SW.Surl.Sdk
{
    public class SurlClient : ApiClientBase<SurlClientOptions>
    {
        public SurlClient(HttpClient httpClient, RequestContext requestContext, SurlClientOptions options) : base(httpClient, requestContext, options) { }
        
        public async Task<string> CreateShortUrl(string url)
        {
            return await Builder
                .Path("urls")
                .As<string>()
                .PostAsync(new ShortUrlCreate()
                {
                    Url = url
                });
        }
    }
}