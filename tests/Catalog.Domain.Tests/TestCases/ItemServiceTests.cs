using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;
using Catalog.Domain.Services;
using Catalog.Fixtures.Persistence;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;


namespace Catalog.Domain.Tests.TestCases
{
    public class ItemServiceTests :
        IClassFixture<CatalogContextFactory>
    {
        private readonly IMapper _mapper;
        private readonly ItemRepository _repository;


        public ItemServiceTests(CatalogContextFactory catalogContextFactory)
        {
            _repository = new ItemRepository(catalogContextFactory.ContextInstance);
            _mapper = catalogContextFactory.Mapper;
        }

        [Fact]
        public async Task get_items_should_return_right_data()
        {
            ItemService sut = new(_mapper, _repository);
            IEnumerable<ItemResponse> result = await sut.GetItemsAsync();
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task get_item_should_return_right_data(string guid)
        {
            ItemService sut = new(_mapper, _repository);
            ItemResponse? result = await sut.GetItemAsync(
                new GetItemRequest {Id = new Guid(guid)}
                );

            result.ShouldNotBeNull();
            if (result != null)
            {
                result.Id.ShouldBe(new Guid(guid));
            }
        }

        [Fact]
        public async Task get_item_should_thrown_exception_with_null_id()
        {
            ItemService sut = new(_mapper, _repository);
            sut.GetItemAsync(null).ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task add_item_should_add_right_entity()
        {
            var testItem = new AddItemRequest
            {
                Name = "Test album",
                Description = "Description",
                LabelName = "Label name",
                Price = new Money { Amount = 13, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                Format = "Vinyl 33g",
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

            IItemService sut = new ItemService(_mapper, _repository);

            var result =
                await sut.AddItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
            result.Price!.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
        }

        [Fact]
        public async Task edititem_should_add_right_entity()
        {
            var testItem = new EditItemRequest
            {
                Id = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e"),
                Name = "Test album",
                Description = "Description",
                LabelName = "Label name",
                Price = new Money { Amount = 13, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                Format = "Vinyl 33g",
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

            ItemService sut = new ItemService(_mapper, _repository);

            var result =
                await sut.EditItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
            result.Price!.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
        }

    }
}
