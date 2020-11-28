using System;
using System.Threading.Tasks;
using SW.PrimitiveTypes;
using SW.Surl.Data;
using SW.Surl.Domain;
using SW.Surl.Model;

namespace SW.Surl.Resources.Urls
{
    public class Create : ICommandHandler<CreateShortUrl>
    {
        private readonly SurlDbContext db;

        public Create(SurlDbContext db)
        {
            this.db = db;
        }
        public async Task<object> Handle(CreateShortUrl request)
        {
            ShortenedUrl entity;

            do
            {
                string unique = Guid.NewGuid().
                    ToString("N").Substring(0, 5);
                
                entity = await db.Set<ShortenedUrl>().FindAsync(unique);
                
            } while (entity != null);

            db.Add(new ShortenedUrl(request.FullUrl));

            await db.SaveChangesAsync();

            return null;
        }
    }
}