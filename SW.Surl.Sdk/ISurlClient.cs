using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SW.PrimitiveTypes;
using SW.Surl.Model;

namespace SW.Surl.Sdk
{
    public interface ISurlClient
    {
        public Task<ShortUrlInfo> CreateShortUrl(string url);
    }
}