using System;
using AutoMapper;
using Catalog.Domain.Mappers;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Fixtures.Persistence
{
    public class CatalogContextFactory
    {
        public readonly CatalogContextTest ContextInstance;
        public readonly IMapper Mapper;

        public CatalogContextFactory()
        {
            var contextOptions = (new DbContextOptionsBuilder<CatalogContext>())
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            EnsureCreation(contextOptions);
            ContextInstance = new CatalogContextTest(contextOptions);

            if (Mapper == null)
            {
                MapperConfiguration mapperConfiguration = new(mc =>
                {
                    mc.AddProfile(new CatalogProfile());
                });
                Mapper = mapperConfiguration.CreateMapper();
            }
        }

        private void EnsureCreation(DbContextOptions<CatalogContext> contextOptions)
        {
            using CatalogContextTest context = new(contextOptions);
            context.Database.EnsureCreated();
        }
    }
}
