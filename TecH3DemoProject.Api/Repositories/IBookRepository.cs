using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> Create(Book book);
        Task<Book> Update(Book book);
        Task<Book> Delete(int id);
    }
}
