using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        void DeleteAsync(int id);
        //Task<Author> DeleteAsync(Author author);
    }
}
