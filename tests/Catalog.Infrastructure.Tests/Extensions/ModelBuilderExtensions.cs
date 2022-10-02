using System.Collections.Generic;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Tests.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Tests.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            Seed<Artist>(modelBuilder, "./Data/artist.json");
            Seed<Genre>(modelBuilder, "./Data/genre.json");
            Seed<Item>(modelBuilder, "./Data/item.json");
            return modelBuilder;
        }

        private static void Seed<TEntity>(ModelBuilder modelBuilder, string file)
        where TEntity : class
        {
            IEnumerable<TEntity> data = CatalogContextTestSeed
                .GetPreconfiguredData<TEntity>(file);
            modelBuilder.Entity<TEntity>().HasData(data);
        }
    }
}
