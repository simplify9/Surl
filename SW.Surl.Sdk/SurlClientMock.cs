using System.Threading.Tasks;
using SW.PrimitiveTypes;

namespace SW.Surl.Sdk
{
    public class SurlClientMock : ISurlClient
    {
        public async Task<ApiResult<string>> GetFullUrl(string key)
        {
            
            if (key == "ggl")
            {
                return new ApiResult<string>()
                {
                    Success = true,
                    Response = "https://www.google.com"
                };
            }

            return new ApiResult<string>()
            {
                Success = false
            };
        }
    }
}