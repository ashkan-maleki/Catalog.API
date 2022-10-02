using Catalog.Infrastructure.Tests.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Tests.Persistence
{
    public class CatalogContextTest : CatalogContext
    {
        public CatalogContextTest(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
