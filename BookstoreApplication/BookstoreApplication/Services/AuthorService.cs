using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> AddAsync(Author author)
        {
            Author newAuthor = await _authorRepository.AddAsync(author);
            return newAuthor;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            Author newAuthor = await _authorRepository.UpdateAsync(author);
            return newAuthor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return false;
            }

            return await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);
            return author;
        }
    }
}
