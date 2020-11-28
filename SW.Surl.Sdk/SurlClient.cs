using System;
using System.Net.Http;
using System.Threading.Tasks;
using SW.HttpExtensions;
using SW.PrimitiveTypes;

namespace SW.Surl.Sdk
{
    public class SurlClient : ApiClientBase<SurlClientOptions>, ISurlClient
    {
        public SurlClient(HttpClient httpClient, RequestContext requestContext, SurlClientOptions options) : base(httpClient, requestContext, options) { }
        
        public async Task<ApiResult<string>> GetFullUrl(string key)
        {
            return await Builder
                .Path($"maps/{key}")
                .AsApiResult<string>()
                .GetAsync();
        }
    }
}