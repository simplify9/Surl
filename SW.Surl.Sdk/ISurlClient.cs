using System.Threading.Tasks;
using SW.PrimitiveTypes;

namespace SW.Surl.Sdk
{
    public interface ISurlClient
    {
        public Task<ApiResult<string>> GetFullUrl(string key);
    }
}