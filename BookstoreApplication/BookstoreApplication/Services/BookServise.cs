using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class BookService : IBookServise
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, IMapper mapper, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _logger.LogInformation($"Trying to add a new book.");
            if (book == null)
            {
                _logger.LogError($"Book data is null or invalid.");
                throw new BadRequestException("Invalid book data.");
            }

            var addedBook = await _bookRepository.AddAsync(book);
            _logger.LogInformation($"Book with Id {addedBook.Id} was successfully added.");
            return addedBook;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            _logger.LogInformation($"Updating book with Id {id}.");
            if (book == null)
            {
                _logger.LogError($"Book data is null or invalid.");
                throw new BadRequestException("Invalid book data.");
            }

            if (book.Id != id)
            {
                _logger.LogError($"Book Id {book.Id} does not match parameter Id {id}.");
                throw new BadRequestException("Identifier value is invalid.");
            }

            if (book.AuthorId == 0)
            {
                _logger.LogError($"Author with Id {book.AuthorId} not found.");
                throw new NotFoundException(book.AuthorId);
            }

            if (book.PublisherId == 0)
            {
                _logger.LogError($"Publisher with Id {book.PublisherId} not found.");
                throw new NotFoundException(book.PublisherId);
            }

            var updatedBook = await _bookRepository.UpdateAsync(book);
            _logger.LogInformation($"Book with Id {updatedBook.Id} was successfully updated.");

            return updatedBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation($"Checking if book with Id {id} exists.");
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Book with Id {id} does not exist.");
                throw new NotFoundException(id);
            }
            var result = await _bookRepository.DeleteAsync(id);
            _logger.LogInformation($"Book with Id {id} was deleted.");
            return result;
        }

        public async Task<List<BookDto>> GetAllAsync(string order, string orderDirection)
        {
            _logger.LogInformation($"Retrieving all books.");
            var books = await _bookRepository.GetAllAsync(order, orderDirection);

            if (books == null)
            {
                _logger.LogInformation($"No books found.");
                return new List<BookDto>();
            }

            _logger.LogInformation($"{books.Count} books retrieved successfully.");
            return books.Select(_mapper.Map<BookDto>).ToList();
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            if (books == null)
            {
                return new List<BookDto>();
            }

            return books.Select(_mapper.Map<BookDto>).ToList();
        }

        public async Task<BookDetailsDto> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving book with Id {id}.");
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Book with Id {id} does not exist.");
                throw new NotFoundException(id);
            }
            _logger.LogInformation($"Book with Id {book.Id} retrieved successfully.");
            return _mapper.Map<BookDetailsDto>(book);
        }
        public async Task<Book> GetBookByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving book with Id {id}.");
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Book with Id {id} does not exist.");
                throw new NotFoundException(id);
            }
            _logger.LogInformation($"Book with Id {book.Id} retrieved successfully.");
            return book;
        }

        public async Task<List<BookDto>> BookSearchAsync(BookSearchDto bookSearchDto)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            bool isEmpty = string.IsNullOrEmpty(bookSearchDto.Title)
                && bookSearchDto.PublishedTo == null
                && bookSearchDto.PublishedFrom == null
                && bookSearchDto.AuthorId == null
                && string.IsNullOrEmpty(bookSearchDto.AuthorName)
                && bookSearchDto.AuthorBirthDateFrom == null
                && bookSearchDto.AuthorBirthDateTo == null;

            if (isEmpty)
            {
                return books.Select(_mapper.Map<BookDto>).ToList();
            }

            var searchBooks = await _bookRepository.BookSearchAsync(bookSearchDto);
            if (searchBooks.Count == 0)
            {
                throw new BadRequestException("Book not found.");
            }
            return searchBooks.Select(_mapper.Map<BookDto>).ToList();
        }
    }
}