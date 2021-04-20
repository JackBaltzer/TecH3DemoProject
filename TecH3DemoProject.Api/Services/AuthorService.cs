using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Author> CreateAsync(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Task<Author> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            return author;
        }

        public Task<Author> UpdateAsync(int id, string firstname, string lastname)
        {
            throw new NotImplementedException();
        }
    }
}
