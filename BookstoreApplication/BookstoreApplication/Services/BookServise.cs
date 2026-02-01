using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class BookServise : IBookServise
    {
        private readonly IBookRepository _bookRepository;

        public BookServise(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
    }
}
