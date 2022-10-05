using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Requests.Item.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Catalog.Domain.Tests.TestCases
{
    public class EditItemRequestValidatorTests
    {
        private readonly TestValidationResult<EditItemRequest> _testValidationResult;
        public EditItemRequestValidatorTests()
        {
            var validator = new EditItemRequestValidator();
            var editItemRequest = new EditItemRequest { Price = new Money() };
            _testValidationResult = validator.TestValidate(editItemRequest);
        }

        [Fact]
        public void should_have_error_when_Id_is_null()
        {
            _testValidationResult
                .ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void should_have_error_when_ArtistId_is_null()
        {
            _testValidationResult
                .ShouldHaveValidationErrorFor(x => x.GenreId);
        }

        [Fact]
        public void should_have_error_when_GenreId_is_null()
        {
            _testValidationResult
                .ShouldHaveValidationErrorFor(x => x.GenreId);
        }
    }
}