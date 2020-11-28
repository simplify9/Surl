using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SW.PrimitiveTypes;
using SW.Surl.Data;
using SW.Surl.Domain;
using SW.Surl.Model;
using SW.Surl.Sdk;

namespace SW.Surl.Resources.Urls
{
    public class Get : IGetHandler<string>
    {
        private readonly SurlDbContext db;

        public Get(SurlDbContext db)
        {
            this.db = db;
        }
        public async Task<object> Handle(string key, bool lookup = false)
        {
            ShortenedUrl url = await db.Set<ShortenedUrl>().FindAsync(key);
            
            if (url == null)
                throw new SWNotFoundException(nameof(key));
            
            return new GetShortUrl
            {
                ExpiresOn = url.ExpiresOn,
                FullUrl = url.FullUrl
            };
        }
    }
}