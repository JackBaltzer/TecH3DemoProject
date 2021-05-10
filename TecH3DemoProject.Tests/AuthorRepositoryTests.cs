using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Database;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;
using Xunit;

namespace TecH3DemoProject.Tests
{
    public class AuthorRepositoryTests
    {

        private DbContextOptions<TecH3DemoContext> _options;

        public AuthorRepositoryTests()
        {

            _options = new DbContextOptionsBuilder<TecH3DemoContext>()
                .UseInMemoryDatabase(databaseName: "AuthorsDataBase")
                .Options;
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllAuthors_WhenAuthorsExists()
        {

            // Arrange

            using (var context = new TecH3DemoContext(_options))
            {
                context.Author.Add(new Author
                {
                    Id = 1,
                    FirstName = "Albert",
                    LastName = "Andersen"
                });
                context.Author.Add(new Author
                {
                    Id = 2,
                    FirstName = "Benny",
                    LastName = "Bomstærk"
                });
                context.SaveChanges();
   
                AuthorRepository authorRepository = new AuthorRepository(context);

                // Act
                var author = await authorRepository.GetById(1);

                // Assert
                Assert.Equal(1, author.Id);
                Assert.Equal("Albert", author.FirstName);
                Assert.Equal("Andersen", author.LastName);
            }
        }
    }
}
