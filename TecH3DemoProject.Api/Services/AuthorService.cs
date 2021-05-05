using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;

namespace TecH3DemoProject.Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAll();
            // måske sorteres, eller på anden vis manipuleres inden data returneres
            return authors;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetById(id);
            return author;
        }

        public async Task<Author> CreateAsync(string firstname, string lastname)
        {
            var author = new Author
            {
                FirstName = firstname,
                LastName = lastname
            };

            author = await _authorRepository.Create(author);
            return author;
        }

        public async Task<Author> UpdateAsync(int id, string firstname, string lastname)
        {
            Author author = new Author
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname
            };
            await _authorRepository.Update(author);
            return author;
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await _authorRepository.Delete(id);
            return author;
        }
    }
}
