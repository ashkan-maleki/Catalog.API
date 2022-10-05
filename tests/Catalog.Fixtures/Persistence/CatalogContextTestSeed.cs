using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Catalog.Fixtures.Persistence
{
    public class CatalogContextTestSeed
    {
        public static  IEnumerable<TEntity>
            GetPreconfiguredData<TEntity>(string file)
            where TEntity : class
        {
            using StreamReader reader = new(file);
            string json = reader.ReadToEnd();
            return (JsonConvert
                        .DeserializeObject<TEntity[]>(json)
                    ?? Array.Empty<TEntity>()).ToList();
        }

        public static async Task<IEnumerable<TEntity>> 
            GetPreconfiguredDataAsync<TEntity>(string file)
        where TEntity : class
        {
            using StreamReader reader = new(file);
            string json = await reader.ReadToEndAsync();
            return (JsonConvert
                        .DeserializeObject<TEntity[]>(json)
                    ?? Array.Empty<TEntity>()).ToList();
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
