using Application.Features.Queries.GetPerfume;
using FluentAssertions;


namespace Tests.Validator
{
    public class GetPerfumeQueryValidatorTests
    {
        private GetPerfumeQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new GetPerfumeQueryValidator();
        }

        [Test]
        public void GetPerfumeQueryValidator_ValidPayload_ShouldBeValid()
        {
            //Arange
            var getPerfumeQuery = this.GetPayload(1);

            //Act
            var result = this._validator.Validate(getPerfumeQuery);

            //Assert
            result.IsValid.Should().BeTrue();  
        }

        [Test]
        public void GetPerfumeQueryValidator_IdIsZero_ShouldBeInvalid()
        {
            // Arrage
            var getPerfumeQuery = this.GetPayload(0);

            // Act
            var result = this._validator.Validate(getPerfumeQuery);

            // Assert
            result.IsValid.Should().BeFalse();    
        }

        [Test]
        public void GetperfumeQueryValidator_IdIsNegative_ShouldBeInvalid()
        {
            // Arrange
            var getPerfumeQuery = this.GetPayload(-2);

            // Act
            var result = this._validator.Validate(getPerfumeQuery);

            // Assert
            result.IsValid.Should().BeFalse();
        }


        private GetPerfumeQuery GetPayload(int id)
        {
            return new GetPerfumeQuery(id);
        }
    }
}
