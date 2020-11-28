using System.Threading.Tasks;
using SW.PrimitiveTypes;

namespace SW.Surl.Sdk
{
    public class SurlClientMock : ISurlClient
    {
        public async Task<ApiResult<string>> GetFullUrl(string key)
        {
            
            if (key == "sf9")
            {
                return new ApiResult<string>()
                {
                    Success = true,
                    Response = "https://www.simplify9.com"
                };
            }

            return new ApiResult<string>()
            {
                Success = false
            };
        }
    }
}