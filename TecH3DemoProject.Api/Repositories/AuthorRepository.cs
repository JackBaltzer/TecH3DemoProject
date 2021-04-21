using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Database;
using TecH3DemoProject.Api.Domain;
using System.Linq;

namespace TecH3DemoProject.Api.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly TecH3DemoContext _context;

        public AuthorRepository(TecH3DemoContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Author.ToListAsync();
            return authors;
        }
       
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Author.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
               _context.Author.Remove(author);
            }
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
