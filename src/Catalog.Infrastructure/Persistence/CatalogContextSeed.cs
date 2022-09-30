using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure.Persistence
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(
            CatalogContext context,
            ILogger<CatalogContextSeed> logger)
        {
            if (context.Items != null && !context.Items.Any())
            {
                context.Items.AddRange(GetPreconfiguredItems());
                await context.SaveEntitiesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CatalogContext).Name);
            }
        }

        private static IEnumerable<Item> GetPreconfiguredItems()
            => new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello",
                    AvailableStock = 5,
                    Description = "Very good",
                    Format = "CD",
                    IsInactive = false,
                }
            };
    }
}
