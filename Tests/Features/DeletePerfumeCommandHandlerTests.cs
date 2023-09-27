using Application.Exceptions;
using Application.Features.Commands.DeletePerfume;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features
{
    internal class DeletePerfumeCommandHandlerTests
    {
        private DeletePerfumeCommandHandler _systemUnderTest;
        private Mock<IDataContext> _dataContextMock;

        [SetUp]
        public void Setup() => this._dataContextMock = new Mock<IDataContext>();

        [Test]
        public void DeletePerfumeCommand_PerfumeDoesNotExsist_ShouldThrowEntityNotFoundException()
        {
            // Arrange

            var perfumes = new List<Perfume>();

            this._dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            this._systemUnderTest = new DeletePerfumeCommandHandler(this._dataContextMock.Object);

            // Act & Assert
            this._systemUnderTest.Invoking(x => x.Handle(new DeletePerfumeCommand(250), new CancellationToken()))
                .Should().ThrowAsync<EntityNotFoundException>();
                
        }

        [Test]
        public void DeletePerfumeCommand_DeletePerfumeWithGivenId_ShouldDeletePerfume()
        {
            // Arrange
            var perfumes = new List<Perfume>
            {
                new Perfume
                {
                    Id = 3,
                    Brand = "Test Brand",
                    Name = "Test Name",
                    ImageUrl = "Test ImageUrl",
                    Scent = "Test Scent",
                    Volume = 110f
                }
            };

            this._dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            this._systemUnderTest = new DeletePerfumeCommandHandler(this._dataContextMock.Object);

            // Act & Assert
            this._systemUnderTest.Invoking(x =>
                x.Handle(new DeletePerfumeCommand(3), new CancellationToken()))
                .Should().NotThrowAsync();
            this._dataContextMock.Verify(dataContext => dataContext.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once());

        }

        [Test]
        public void DeletePerfumeCommand_TwoMoviesWithSameId_ShouldThrowInvalidOperationexception()
        {
            // Arrange
            var perfumes = new List<Perfume> 
            { 
                new Perfume 
                {
                    Id = 3,
                    Brand = "Test Brand",
                    Name = "Test Name",
                    ImageUrl = "Test ImageUrl",
                    Scent = "Test Scent",
                    Volume = 110f 
                },
                new Perfume 
                {
                    Id = 3,
                    Brand = "Test Brand",
                    Name = "Test Name",
                    ImageUrl = "Test ImageUrl",
                    Scent = "Test Scent",
                    Volume = 110f
                } 
            };

            this._dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            this._systemUnderTest = new DeletePerfumeCommandHandler(this._dataContextMock.Object);

            // Act & Assert
            this._systemUnderTest.Invoking(x => x.Handle(new DeletePerfumeCommand(3), new CancellationToken()))
                .Should().ThrowAsync<InvalidOperationException>();
            this._dataContextMock.Verify(dataContext => dataContext.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Exactly(0));

        }
    }
}
