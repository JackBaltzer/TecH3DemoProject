using Microsoft.EntityFrameworkCore;
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
        private readonly TecH3DemoContext _context;

        public AuthorRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3DemoContext>()
                .UseInMemoryDatabase(databaseName: "AuthorsDataBase")
                .Options;

            _context = new TecH3DemoContext(_options);


            _context.Database.EnsureDeleted();
            _context.Author.Add(new Author
            {
                Id = 1,
                FirstName = "Albert",
                LastName = "Andersen"
            });
            _context.Author.Add(new Author
            {
                Id = 2,
                FirstName = "Benny",
                LastName = "Bomstærk"
            });
            _context.Author.Add(new Author
            {
                Id = 3,
                FirstName = "Carlo",
                LastName = "Cool"
            });
            _context.SaveChanges();

        }

        [Fact]
        public async Task GetAuthorById_ShouldReturnAllAuthor_WhenAuthorExists()
        {
            // Arrange
            AuthorRepository authorRepository = new AuthorRepository(_context);

            // Act
            var author = await authorRepository.GetById(1);

            // Assert
            Assert.Equal(1, author.Id);
            Assert.Equal("Albert", author.FirstName);
            Assert.Equal("Andersen", author.LastName);

        }

        [Fact]
        public async Task GetAllAuthor_ShouldReturnAllAuthors_WhenAuthorsExists()
        {
            // Arrange
            AuthorRepository authorRepository = new AuthorRepository(_context);

            // Act
            var author = await authorRepository.GetAll();

            // Assert
            Assert.Equal(3, author.Count);
        }
    }
}
