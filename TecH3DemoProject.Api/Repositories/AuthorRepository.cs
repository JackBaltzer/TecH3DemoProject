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

        public async Task<List<Author>> GetAll()
        {
            var authors = await _context.Author.Where(a => a.deletedAt == null).ToListAsync();
            return authors;
        }

        public async Task<Author> GetById(int id)
        {
            var author = await _context.Author.Where(a => a.deletedAt == null).FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<Author> Create(Author author)
        {
            author.createdAt = DateTime.Now;
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            var editAuthor = await _context.Author.FirstOrDefaultAsync(a => a.Id == author.Id);
            editAuthor.updatedAt = DateTime.Now;
            editAuthor.FirstName = author.FirstName;
            editAuthor.LastName = author.LastName;
            _context.Author.Update(editAuthor);
            await _context.SaveChangesAsync();
            return editAuthor;
        }

        public async Task<Author> Delete(int id)
        {
            var author = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                author.deletedAt = DateTime.Now;
                
            }
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
