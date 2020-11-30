using System.Threading.Tasks;
using SW.PrimitiveTypes;
using SW.Surl.Data;
using SW.Surl.Domain;
using SW.Surl.Model;

namespace SW.Surl.Resources.l
{
    [Unprotect]
    public class Redirect : IGetHandler<string>
    {
        private readonly SurlDbContext db;

        public Redirect(SurlDbContext db)
        {
            this.db = db;
        }
        public async Task<object> Handle(string key, bool lookup = false)
        {
            
            ShortenedUrl url = await db.Set<ShortenedUrl>().FindAsync(key);

            if (url == null) return null;

            return new CqApiResult<string>(url.FullUrl)
            {
                Status = CqApiResultStatus.ChangedLocation
            };
        }
    }
}