using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SW.PrimitiveTypes;
using SW.Surl.Domain;
using SW.Surl.Model;

namespace SW.Surl.Resources.Urls
{
    [Protect]
    public class Create : ICommandHandler<ShortUrlCreate>
    {
        private readonly SurlDbContext db;

        public Create(SurlDbContext db)
        {
            this.db = db;
        }
        public async Task<object> Handle(ShortUrlCreate request)
        {
            
            var csp = new RNGCryptoServiceProvider();
            ShortUrl entity;
            string unique;


            do
            {
                byte[] buffer = new byte[9];
                csp.GetBytes(buffer);
                unique = Convert.ToBase64String(buffer);

                entity = await db.Set<ShortUrl>().FindAsync(unique);

            } while (entity != null);

            db.Add(new ShortUrl(unique, request.FullUrl));

            await db.SaveChangesAsync();

            return unique; ;
        }
    }
}