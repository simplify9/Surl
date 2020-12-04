using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SW.Surl.Domain;

namespace SW.Surl
{
    class ExpiredUrlCleanUpService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public ExpiredUrlCleanUpService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        async protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = serviceProvider.CreateScope();
                    using var db = scope.ServiceProvider.GetService<SurlDbContext>();

                    db.Set<ShortUrl>()
                        .RemoveRange(db.Set<ShortUrl>().Where(s => s.CreatedOn < DateTime.UtcNow.AddDays(-30)));

                    await db.SaveChangesAsync();  
                }
                catch (Exception)
                {

                    throw;
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(50), stoppingToken);

        }
    }
}