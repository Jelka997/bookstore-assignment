using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
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
            Book newBook = await _bookRepository.AddAsync(book);
            return newBook;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            Book newBook = await _bookRepository.UpdateAsync(book);
            return newBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return false;
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
            if (book == null) return null;
            return _mapper.Map<BookDetailsDto>(book);
        }
    }
}
