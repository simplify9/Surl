using Microsoft.EntityFrameworkCore;
using SW.EfCoreExtensions;
using SW.PrimitiveTypes;
using SW.Surl.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Surl
{
    public class SurlDbContext : DbContext
    {
        public const string ConnectionString = "SurlDb";
        public const string Schema = "surl";
        private readonly RequestContext requestContext;

        public SurlDbContext(DbContextOptions<SurlDbContext> options, RequestContext requestContext) : base(options)
        {
            this.requestContext = requestContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<ShortUrl>(b =>
            {
                b.Property(url => url.Id).IsCode(20);
                b.Property(url => url.FullUrl).HasMaxLength(2000).IsRequired();

            });

            modelBuilder.CommonProperties(b =>
            {
                b.HasAudit(50);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.ApplyAuditValues(requestContext.GetNameIdentifier());
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}