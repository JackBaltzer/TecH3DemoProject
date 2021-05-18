using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Create(Author author);
        Task<Author> Update(int id, Author author);
        Task<Author> Delete(int id);
        //Task<Author> Delete(Author author);
    }
}
