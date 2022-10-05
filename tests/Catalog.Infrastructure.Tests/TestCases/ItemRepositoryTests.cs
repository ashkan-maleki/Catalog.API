using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Fixtures.Persistence;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;


namespace Catalog.Infrastructure.Tests.TestCases
{
    public class ItemRepositoryTests :
        IClassFixture<CatalogContextFactory>
    {
        private readonly CatalogContextTest _context;
        private readonly ItemRepository _sut;


        public ItemRepositoryTests(CatalogContextFactory catalogContextFactory)
        {
            _context = catalogContextFactory.ContextInstance;
            _sut = new ItemRepository(_context);
        }

        private Item GetTestItem(string description = "Description")
            => new()
            {
                Name = "Test album",
                Description = description,
                LabelName = "Label name",
                Price = new Money {Amount = 13, Currency = "EUR"},
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

        [Fact]
        public async Task should_get_data()
        {
            IReadOnlyList<Item> result = await _sut.GetAsync();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_returns_null_with_id_not_present()
        {
            Item? result = await _sut.GetAsync(Guid.NewGuid());
            result.ShouldBeNull();
        }

        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task should_return_record_by_id(string guid)
        {
            Item? result = await _sut.GetAsync(new Guid(guid));
            result!.Id.ShouldBe(new Guid(guid));
        }

        [Fact]
        public async Task should_add_new_item()
        {
            Item item = GetTestItem();

            _sut.Add(item);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            _context.Items!
                .FirstOrDefault(x => x.Id == item.Id)
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task should_update_item()
        {
            Item item = GetTestItem(
                "Description updated"
                );

            item.Id = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e");

            _sut.Update(item);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            _context.Items!
                .FirstOrDefault(x => x.Id == item.Id)
                ?.Description.ShouldBe("Description updated");
        }

    }
}
