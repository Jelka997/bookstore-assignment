using BookstoreApplication.Data;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServise _bookServise;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;

        public BooksController(IBookServise bookServise, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookServise = bookServise;
            _publisherService = publisherService;
            _authorService = authorService;
        }


        // GET: api/books
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string order = "Name", string orderDirection = "ASC")
        {
            List<BookDto> books = await _bookServise.GetAllAsync(order, orderDirection);
            return Ok(books);
        }


        // GET: api/books/search
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] BookSearchDto bookSearchDto)
        {
            List<BookDto> books = await _bookServise.BookSearchAsync(bookSearchDto);
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var book = await _bookServise.GetByIdAsync(id);
            return Ok(book);
        }

        // POST api/books
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync(Book book)
        {
            // kreiranje knjige je moguće ako je izabran postojeći autor
            var author = await _authorService.GetByIdAsync(book.AuthorId);
            // kreiranje knjige je moguće ako je izabran postojeći izdavač
            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            book.Author = author;
            book.Publisher = publisher;
            var newBook = await _bookServise.AddAsync(book);
            return Ok(newBook);
        }

        // PUT api/books/5
        [Authorize(Policy = "UpdateBook")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Book book)
        {
            var existingBook = await _bookServise.GetBookByIdAsync(id); 

            if (existingBook == null)
                return NotFound();

            existingBook.Title = book.Title;
            existingBook.PageCount = book.PageCount;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublisherId = book.PublisherId;

            var updatedBook = await _bookServise.UpdateAsync(id,existingBook);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [Authorize(Policy = "DeleteBook")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _bookServise.DeleteAsync(id);
            return NoContent();
        }
    }
}
