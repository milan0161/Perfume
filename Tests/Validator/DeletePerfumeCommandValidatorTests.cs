using Application.Features.Commands.DeletePerfume;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Validator
{
    internal class DeletePerfumeCommandValidatorTests
    {
        private DeletePerfumeCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new DeletePerfumeCommandValidator();
        }

        [Test]
        public void DeletePerfumeCommandValidator_ValidPayload_ShouldBeValid()
        {
            // Arrange
            var deletePerfumeCommand = GetValidPayload();

            // Act & Assert
            this._validator.Validate(deletePerfumeCommand).IsValid.Should().BeTrue();
        }

        [Test]
        public void DeletePerfumeCommandValidator_IdIsZero_ShouldBeInvalid()
        {
            // Act & Assert
            var deletePerfumeCommand = GetValidPayload() with {  Id = 0 };

            // Act & Assert
            this._validator.Validate(deletePerfumeCommand).IsValid.Should().BeFalse();
        }


        [Test]
        public void DeletePerfumeCommandValidator_IdIsNegative_ShouldBeInvalid()
        {
            // Act & Assert
            var deletePerfumeCommand = GetValidPayload() with { Id = -5 };

            // Act & Assert
            this._validator.Validate(deletePerfumeCommand).IsValid.Should().BeFalse();
        }

        private DeletePerfumeCommand GetValidPayload()
        {
            return new DeletePerfumeCommand(3);
        }
    }
}
