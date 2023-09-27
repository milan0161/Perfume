

using Application.DTOs;
using Application.Exceptions;
using Application.Features.Commands.UpdatePerfume;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features
{
    public sealed class UpdatePerfumeCommandHandlerTests
    {
        private UpdatePerfumeCommandHandler systemUnderTest;
        private Mock<IDataContext> dataContextMock;

        [SetUp]
        public void Setup() => this.dataContextMock = new Mock<IDataContext>();


        [Test]
        public async Task UpdatePerfumeCommand_UpdatePerfumeWithEmptyParameters_ShouldStaySameAync()
        {
            //Arange
            const int id = 1;

            var perfumes = new List<Perfume>
            {
                new()
                {
                    Id = id,
                    Name = "Test Name",
                    Brand = "Test Brand",
                    Volume = 110f,
                    Scent = "Test Scent",
                    ImageUrl = "Test ImageUrl"
                }
            };

            this.dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            this.systemUnderTest = new UpdatePerfumeCommandHandler(this.dataContextMock.Object);

            var updatePerfumeDto = ConvertToUpdatePerfumeDto(perfumes.First());

            // Act
            var result = await this.systemUnderTest.Handle(new UpdatePerfumeCommand(updatePerfumeDto), new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Perfume>();
            result.Id.Should().Be(perfumes.First().Id);
            result.Name.Should().Be(perfumes.First().Name);
            result.Brand.Should().Be(perfumes.First().Brand);
            result.Scent.Should().Be(perfumes.First().Scent);
            result.Volume.Should().Be(perfumes.First().Volume);
            result.ImageUrl.Should().Be(perfumes.First().ImageUrl);
        }

        [Test]
        public void UpdatePerfumeCommand_UpdatePerfumeThatDoesNotExist_ShoulThroeEntityNotFoundException()
        {
            // Arrange

            var perfumes = new List<Perfume>
            {
                new Perfume
                {
                    Id = 1,
                    Name = "Test Name",
                    Brand = "Test Brand",
                    Volume = 110f,
                    Scent = "Test Scent",
                    ImageUrl = "Test ImageUrl"
                }
            };

            this.dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            this.systemUnderTest = new UpdatePerfumeCommandHandler(this.dataContextMock.Object);

            var updatePerfumeDto = new UpdatePerfumeDto(3, "Test Name", "Test Brand 1", "Test ImageUrl 1", 100f, "Test Scent 1");

            // Act && Assert
            
            this.systemUnderTest
                .Invoking(x => x.Handle(new UpdatePerfumeCommand(updatePerfumeDto), new CancellationToken()))
                .Should().ThrowAsync<EntityNotFoundException>();
              
                
        }

        private UpdatePerfumeDto ConvertToUpdatePerfumeDto(Perfume perfume)
        {
            return new UpdatePerfumeDto(perfume.Id, perfume.Name, perfume.Brand, perfume.ImageUrl, perfume.Volume, perfume.Scent);
        }
    }
}
