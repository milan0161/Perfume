using Application.Features.Queries.GetPerfume;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features
{
    public class GetPerfumeQueryHandlerTests
    {
        private GetPerfumeQueryHandler systemUnderTest;
        private Mock<IDataContext> dataContextMock;


        [SetUp]
        public void Setup()
        {
            dataContextMock = new Mock<IDataContext>();
        }

        /* patern: AAA
         * A: Arrange (Set up fake data)
         * A: Act (invoke unit to test)
         * A: Assert (Evaluate results)
        */
        // {ActionName}_{TestScenario}_{ShouldHappen}
        [Test]
        public async Task GetPerfumeQuery_FindById_ShouldReturnMovieAsync()
        {
            // Arrange
            int id = 1;
            string brand = "Armany";
            List<Perfume> perfumes = new List<Perfume> { new() { Id = id, Brand = brand } };

            dataContextMock.Setup(x => x.Perfumes).ReturnsDbSet(perfumes);

            systemUnderTest = new GetPerfumeQueryHandler(dataContextMock.Object);

            // Act
            var result = await systemUnderTest.Handle(new GetPerfumeQuery(id), new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Perfume>();
            result?.Id.Should().Be(id);
            result?.Brand.Should().Be(brand);

        }
    }
}