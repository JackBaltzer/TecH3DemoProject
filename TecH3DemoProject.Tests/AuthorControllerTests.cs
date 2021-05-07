using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Controllers;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Services;
using Xunit;

namespace TecH3DemoProject.Tests
{
    public class AuthorControllerTests
    {
        private readonly AuthorController _controller;
        private readonly Mock<IAuthorService> authorService = new();

        public AuthorControllerTests()
        {
            _controller = new AuthorController(authorService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn200_WhenDataExists()
        {
            // Arrange
            List<Author> authors = new List<Author>();
            authors.Add(new Author());
            authors.Add(new Author());

            authorService
                .Setup(s => s.GetAllAuthors())
                .ReturnsAsync(authors);

            // Act
            var result = await _controller.GetAll();

            // Assert
            //specifikt se på det ObjectResult der kommer fra _controller
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }


        [Fact]
        public async Task GetAll_ShouldReturn204_WhenNoDataExists()
        {
            // Arrange
            List<Author> authors = new List<Author>();

            authorService
                .Setup(s => s.GetAllAuthors())
                .ReturnsAsync(authors);

            // Act
            var result = await _controller.GetAll();

            // Assert
            //specifikt se på det ObjectResult der kommer fra _controller
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }


        [Fact]
        public async Task GetAll_ShouldReturn500_WhenAuthorsIsNull()
        {
            // Arrange
            List<Author> authors = null;

            authorService
                .Setup(s => s.GetAllAuthors())
                .ReturnsAsync(authors);

            // Act
            var result = await _controller.GetAll();

            // Assert
            //specifikt se på det ObjectResult der kommer fra _controller
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async Task Create_ShouldReturnStatus400_WhenAuthorSubmittedIsNull()
        {
            // Arrange
            Author author = null;

            authorService
                .Setup(s => s.Create(null))
                .ReturnsAsync(author);

            // Act
            var response = await _controller.Create(author);

            // Assert
            // specifikt se på det ObjectResult der kommer fra _controller
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }


        [Fact]
        public async Task Create_ShouldReturnStatus200_WhenAuthorSubmitIsOk()
        {
            // Arrange
            Author author = new Author { FirstName = "Albert", LastName = "Andersen" };
            authorService
                .Setup(s => s.Create(It.IsAny<Author>()))
                .ReturnsAsync(author);

            // Act
            var response = await _controller.Create(author);

            // Assert
            // specifikt se på det ObjectResult der kommer fra _controller
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }


        [Fact]
        public async Task GetAuthorById_ShouldReturnAuthor_WhenAuthorExists()
        {
            // Arrange
            int id = 1;
            string firstName = "Albert";
            string lastName = "Andersen";

            Author author = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            authorService
                .Setup(s => s.GetAuthorById(It.IsAny<int>()))
                .ReturnsAsync(author);

            // Act
            var response = await _controller.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
