using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task<Author> CreateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
