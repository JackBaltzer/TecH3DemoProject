using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecH3DemoProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return authors;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return author;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<Author> Create(string firstName, string lastName)
        {
            var author = await _authorService.CreateAsync(firstName, lastName);
            return author;
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<Author> Update(int id, string firstName, string lastName)
        {
            var author = await _authorService.UpdateAsync(id, firstName, lastName);
            return author;
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<Author> Delete(int id)
        {
            var author = await _authorService.DeleteAsync(id);
            return author;
        }
    }
}
