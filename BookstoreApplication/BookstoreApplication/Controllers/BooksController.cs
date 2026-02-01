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
    public class BooksController : ControllerBase
    {
        private readonly BookServise _bookServise;
        private readonly PublisherService _publisherService;
        private readonly AuthorService _authorService;

        public BooksController(BookServise bookServise, PublisherService publisherService, AuthorService authorService)
        {
            _bookServise = bookServise;
            _publisherService = publisherService;
            _authorService = authorService;
        }


        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Book> books = await _bookServise.GetAllAsync();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var book = await _bookServise.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> PostAsync(Book book)
        {
            // kreiranje knjige je moguće ako je izabran postojeći autor
            var author = await _authorService.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            // kreiranje knjige je moguće ako je izabran postojeći izdavač
            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            book.Author = author;
            book.Publisher = publisher;
            var newBook = await _bookServise.AddAsync(book);
            return Ok(newBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _bookServise.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            // izmena knjige je moguca ako je izabran postojeći autor
            var author = await _authorService.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            // izmena knjige je moguca ako je izabran postojeći izdavač
            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            existingBook.Title = book.Title;
            existingBook.PageCount = book.PageCount;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            var updatedBook = await _bookServise.UpdateAsync(existingBook);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var book = await _bookServise.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookServise.DeleteAsync(id);
            return NoContent();
        }
    }
}
