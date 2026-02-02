using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Author> authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public async Task<IActionResult> PostAsync(Author author)
        {
            return Ok(await _authorService.AddAsync(author));
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Author author)
        {
            return Ok(await _authorService.UpdateAsync(id, author));
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
