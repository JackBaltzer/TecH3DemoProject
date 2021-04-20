using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Repositories;

using Xunit;
using Moq;

namespace TecH3DemoProject.Tests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _sut;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock = new Mock<IAuthorRepository>();

        public AuthorServiceTests()
        {
            _sut = new AuthorService(_authorRepositoryMock.Object);
        }

        [Fact]

    }
}
