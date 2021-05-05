using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Controllers;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;
using TecH3DemoProject.Api.Services;
using Xunit;

namespace TecH3DemoProject.Tests
{
    public class AuthorControllerTests
    {
        private readonly AuthorController _sut;
        private readonly  Mock<IAuthorService> authorService = new();

        public AuthorControllerTests()
        {
            _sut = new AuthorController(authorService.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnStatus400_WhenAuthorSubmitIsMissingFirstname()
        {
            //authorService
            //    .Setup(s => s.CreateAsync(It.IsAny<string>(), It.IsAny<string>()))
            //    .Returns();
            // specifikt se på det ObjectResult der kommer fra controller
            ObjectResult result = await _sut.Create(new Author { FirstName = "", LastName = "" }) as ObjectResult;

            Assert.Equal(400,  result.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnStatus200_WhenAuthorSubmitIsOk()
        {
            authorService.Setup(s => s.GetAllAuthorsAsync()).Returns(Task.FromResult(new List<Author>()));
            // specifikt se på det ObjectResult der kommer fra controller
            ObjectResult result = await _sut.Create(new Author { FirstName = "Albert", LastName = "Andersen" }) as ObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldReturnListOfAuthors_WhenAuthorsExists()
        {

            authorService.Setup(s => s.GetAllAuthorsAsync()).Returns(Task.FromResult(new List<Author>()));


            var result = await _sut.GetAll();

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldReturnAuthor_WhenAuthorExists()
        {

            authorService.Setup(s => s.GetAuthorByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(new Author()));


            var result = await _sut.Get(1);

            Assert.NotNull(result);
        }
    }
}
