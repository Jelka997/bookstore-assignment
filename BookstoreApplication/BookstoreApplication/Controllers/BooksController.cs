using BookstoreApplication.Data;
using BookstoreApplication.DTOs;
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
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string order = "Name", string orderDirection = "ASC")
        {
            List<BookDto> books = await _bookServise.GetAllAsync(order, orderDirection);
            return Ok(books);
        }


        // GET: api/books/search
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Book book)
        {
            BookDetailsDto existingBook = await _bookServise.GetByIdAsync(id);
           
            // izmena knjige je moguca ako je izabran postojeći autor
            var author = await _authorService.GetByIdAsync(book.AuthorId);
           
            // izmena knjige je moguca ako je izabran postojeći izdavač
            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            
            Book book1 = new Book
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                PageCount = existingBook.PageCount,
                PublishedDate = existingBook.PublishedDate,
                ISBN = existingBook.ISBN,
                AuthorId = existingBook.AuthorId,
                PublisherId = existingBook.PublisherId
            };

            book1.Title = book.Title;
            book1.PageCount = book.PageCount;
            book1.PublishedDate = book.PublishedDate;
            book1.ISBN = book.ISBN;
            var updatedBook = await _bookServise.UpdateAsync(id,book1);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _bookServise.DeleteAsync(id);
            return NoContent();
        }
    }
}
