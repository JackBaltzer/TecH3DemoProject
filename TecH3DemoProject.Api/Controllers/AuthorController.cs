using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecH3DemoProject.Api.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/author
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET api/author/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/author
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            var newAuthor = await _authorService.CreateAsync(author.FirstName, author.LastName);
            if (newAuthor == null)
            {
                return BadRequest("Something went wrong...");
            }
            return Ok(newAuthor);
        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Author author)
        {
            var editAuthor = await _authorService.UpdateAsync(id, author.FirstName, author.LastName);
            if(editAuthor == null)
            {
                return Problem("Edit failed somehow");
            }
            return Ok(editAuthor);
        }

        // DELETE api/author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var author = await _authorService.DeleteAsync(id);
            return Ok(author);
        }
    }
}
