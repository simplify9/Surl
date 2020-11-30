using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using SW.Surl.Data;
using SW.Surl.Domain;

namespace SW.Surl.Services
{
    public class ExpiredUrlCleanUpService : IHostedService
    {
        private readonly SurlDbContext db;

        public ExpiredUrlCleanUpService(SurlDbContext db)
        {
            this.db = db;
        }
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CleanUp, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
            return Task.CompletedTask;
        }

        void CleanUp(object state)
        {
            db.Set<ShortenedUrl>()
                .RemoveRange(
                    db.Set<ShortenedUrl>().Where(s => s.CreatedOn + TimeSpan.FromDays(30) > DateTime.Now)
                );
            //db.SaveChanges();
        }

        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}