using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Requests.Item.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Catalog.Domain.Tests.TestCases
{
    public class AddItemRequestValidatorTests
    {
        private readonly AddItemRequestValidator _validator;

        public AddItemRequestValidatorTests()
        {
            _validator = new AddItemRequestValidator();
        }

        [Fact]
        public void should_have_error_when_artist_id_is_null()
        {
            var addItemRequest = new AddItemRequest { Price = new Money() };
            _validator.TestValidate(addItemRequest)
                .ShouldHaveValidationErrorFor(x => x.ArtistId);
        }

        [Fact]
        public void should_have_error_when_genre_id_is_null()
        {
            var addItemRequest = new AddItemRequest { Price = new Money() };
            _validator.TestValidate(addItemRequest)
                .ShouldHaveValidationErrorFor(x => x.GenreId);
        }
    }
}