﻿using Moq;
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
        //private readonly Mock<IAuthorRepository> _authorRepositoryMock = new Mock<IAuthorRepository>();

        public AuthorServiceTests()
        {
            _sut = new AuthorService(_authorRepositoryMock.Object);
        }

        //[Fact]
        //public void RandomTests()
        //{
        //    // Arrange
        //    int a = 10;
        //    int b = 2;

        //    // Act
        //    int c = a + b;

        //    // Assert
        //    Assert.Equal(12, c);
        //    Assert.Equal(13, c);
        //}

        //[Theory]
        //[InlineData(10, 2)]
        //[InlineData(15, 2)]
        //public void RandomMultitests(int a, int b)
        //{
        //    // Act
        //    int c = a + b;

        //    // Assert
        //    Assert.Equal(12, c);
        //}


        [Fact]
        public async Task Create_ShouldFailIfNullIsPassed()
        {
            // Arrange
            _authorRepositoryMock
                .Setup(x => x.Create(It.IsAny<Author>()))
                .ReturnsAsync(() => null);
            // Act
            var author = await _sut.CreateAsync(null, null);

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
            var author = await _sut.GetAuthorByIdAsync(1);

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
            var author = await _sut.GetAuthorByIdAsync(authorId);

            // Assert
            Assert.Equal(authorId, author.Id);
            Assert.Equal(authorFirstName, author.FirstName);
            Assert.Equal(authorLastName, author.LastName);
        }

    }
}
