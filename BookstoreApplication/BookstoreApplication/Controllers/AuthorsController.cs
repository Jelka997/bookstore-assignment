using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository authorRepository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Author> authors = await authorRepository.GetAllAsync();
            return Ok(authors);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public async Task<IActionResult> PostAsync(Author author)
        {
            return Ok(await authorRepository.AddAsync(author));
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Author author)
        {
            if (author.Id != id)
            {
                return BadRequest();
            }

            return Ok(await authorRepository.UpdateAsync(author));
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await authorRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
