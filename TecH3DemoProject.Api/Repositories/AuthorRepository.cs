using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Database;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly TecH3DemoContext _context;
        public AuthorRepository(TecH3DemoContext context)
        {
            _context = context;
        }


        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Author.ToListAsync();
            return authors;
        }

        public Task<Author> UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
