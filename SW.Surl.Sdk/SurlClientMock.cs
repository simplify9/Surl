using System.Threading.Tasks;
using SW.PrimitiveTypes;

namespace SW.Surl.Sdk
{
    public class SurlClientMock : ISurlClient
    {
        public async Task<ApiResult<string>> GetFullUrl(string key)
        {
            ApiResult<string> rs = new ApiResult<string>();
            rs.Response = "https://www.google.com";
            return rs;
        }
    }
}