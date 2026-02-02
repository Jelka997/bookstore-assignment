using BookstoreApplication.Models;
using BookstoreApplication.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            if(author == null)
            {
                throw new BadRequestException("Invalid data.");
            }
            return await _authorRepository.AddAsync(author);
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            if (author.Id != id)
            {
                throw new BadRequestException("Identifier value is invalid.");
            }
            Author newAuthor = await _authorRepository.UpdateAsync(author);
            return newAuthor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                throw new NotFoundException(id);
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

            if (author == null)
            {
                throw new NotFoundException(id);
            }
            return author;
        }
    }
}
