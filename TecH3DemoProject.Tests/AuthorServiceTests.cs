using Moq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;
using TecH3DemoProject.Api.Services;
using Xunit;

namespace TecH3DemoProject.Tests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _sut;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock = new();

        public AuthorServiceTests()
        {
            _sut = new AuthorService(_authorRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ShouldFailIfNullIsPassed()
        {
            // Arrange
            _authorRepositoryMock
                .Setup(x => x.Create(It.IsAny<Author>()))
                .ReturnsAsync(() => null);

            // Act
            var author = await _sut.Create(null);

            // Assert
            Assert.Null(author);
        }
            
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNothing_WhenAuthorDoesNotExist()
        {
            // Arrange
            // make the MockRepo return null when any Author is requested
            _authorRepositoryMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            // try to get a single author with the id == 1
            var author = await _sut.GetAuthorById(1);

            // Assert
            Assert.Null(author);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnAuthor_WhenAuthorExists()
        {
            // Arrange
            // setup the Mock author data
            var authorId = 1;
            var authorFirstName = "Albert";
            var authorLastName = "Andersen";
            var mockAuthor = new Author
            {
                Id = authorId,
                FirstName = authorFirstName,
                LastName = authorLastName
            };
            _authorRepositoryMock
                .Setup(x => x.GetById(authorId))
                .ReturnsAsync(mockAuthor);

            // Act
            var author = await _sut.GetAuthorById(authorId);

            // Assert
            Assert.Equal(mockAuthor, author);
            
        }

    }
}
