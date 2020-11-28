using Microsoft.EntityFrameworkCore;
using SW.EfCoreExtensions;
using SW.Surl.Domain;

namespace SW.Surl.Data
{
    public class SurlDbContext : DbContext
    {
        public const string ConnectionString = "SurlDb";
        public const string Schema = "surl";
        public SurlDbContext(DbContextOptions<SurlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);
            
            modelBuilder.Entity<ShortenedUrl>(s =>
            {
                s.Property(url => url.Id).IsCode(5);
            });
        }
    }
}