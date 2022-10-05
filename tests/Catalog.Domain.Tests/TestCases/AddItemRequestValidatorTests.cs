using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Requests.Item.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Catalog.Domain.Tests.TestCases
{
    public class AddItemRequestValidatorTests
    {
        private readonly TestValidationResult<AddItemRequest> _testValidationResult;

        public AddItemRequestValidatorTests()
        {
            var validator = new AddItemRequestValidator();
            var addItemRequest = new AddItemRequest { Price = new Money() };
            _testValidationResult = validator.TestValidate(addItemRequest);
        }

        [Fact]
        public void should_have_error_when_artist_id_is_null()
        {
            _testValidationResult
                .ShouldHaveValidationErrorFor(x => x.ArtistId);
        }

        [Fact]
        public void should_have_error_when_genre_id_is_null()
        {
            _testValidationResult
                .ShouldHaveValidationErrorFor(x => x.GenreId);
        }
    }
}