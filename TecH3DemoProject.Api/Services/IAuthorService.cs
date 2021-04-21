using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAsync(string firstname, string lastname);
        Task<Author> UpdateAsync(int id, string firstname, string lastname);
        Task<Author> DeleteAsync(int id);
    }
}
