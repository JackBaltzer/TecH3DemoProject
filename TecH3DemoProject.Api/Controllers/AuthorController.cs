using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecH3DemoProject.Api.Controllers
{

    // Controller tager sig af HttpRequests og returnerer data til client...
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
            Console.WriteLine("GetAll authors reached");
            // example to illustrate endpoint being testable for pretty much everything
            try
            {
                var authors = await _authorService.GetAllAuthors();
                if (authors == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (authors.Count == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(authors);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }

        // GET api/author/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Console.WriteLine("Fetch single author reached");
            try
            {
                var author = await _authorService.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST api/author
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            Console.WriteLine("Create author reached");
            try
            {
                if (author == null)
                {
                    return BadRequest("Author fail");
                }
                var newAuthor = await _authorService.Create(author);
                return Ok(newAuthor);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Author author)
        {
            Console.WriteLine("Update author reached");
            try
            {
                var editAuthor = await _authorService.Update(id, author);
                if (editAuthor == null)
                {
                    return Problem("Edit failed somehow");
                }
                return Ok(editAuthor);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DELETE api/author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Console.WriteLine("Delete author reached");
            try
            {
                var author = await _authorService.Delete(id);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
