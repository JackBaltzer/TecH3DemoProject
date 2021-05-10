using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;

namespace TecH3DemoProject.Api.Services
{
    // Service tager sig af at hente/send data til/fra data-kilder, som f.eks. lokal database eller eksterne API
    // lokal database tilgåes igennem et repository interface.
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAll();
            return authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetById(id);
            //author.FirstName = "Derp";
            return author;
        }

        public async Task<Author> Create(Author author)
        {
            author = await _authorRepository.Create(author);
            return author;
        }

        public async Task<Author> Update(int id, Author author)
        {
            await _authorRepository.Update(id, author);
            return author;
        }

        public async Task<Author> Delete(int id)
        {
            var author = await _authorRepository.Delete(id);
            return author;
        }
    }
}
