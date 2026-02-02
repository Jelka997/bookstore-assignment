using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class BookServise : IBookServise
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookServise(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public async Task<Book> AddAsync(Book book)
        {
            if(book == null)
            {
                throw new BadRequestException("Invalid data.");
            }
            return await _bookRepository.AddAsync(book); 
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            if (book.Id != id)
            {
                throw new BadRequestException("Identifier value is invalid.");
            }
            if (book.AuthorId == 0)
            {
                throw new NotFoundException(book.AuthorId);
            }
            if (book.PublisherId == 0)
            {
                throw new NotFoundException(book.PublisherId);
            }
            Book newBook = await _bookRepository.UpdateAsync(book);
            return newBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new NotFoundException(id);
            }

            return await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books
                .Select(_mapper.Map<BookDto>)
                .ToList();
        }

        public async Task<BookDetailsDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new NotFoundException(id);
            }
            return _mapper.Map<BookDetailsDto>(book);
        }
    }
}
