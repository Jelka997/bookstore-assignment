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
        public IActionResult GetAll()
        {
            List<Author> authors = authorRepository.GetAll();
            return Ok(authors);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var author = authorRepository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post(Author author)
        {
            return Ok(authorRepository.Add(author));
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Author author)
        {
            if (author.Id != id)
            {
                return BadRequest();
            }

            return Ok(authorRepository.Update(author));
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!authorRepository.Delete(id))
                return NotFound();

            return NoContent();
        }
    }
}
