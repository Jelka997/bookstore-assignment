using BookstoreApplication.DTOs;

namespace BookstoreApplication.Models
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);
        Task<bool> DeleteAsync(int id);
        Task<PaginatedListDto<Author>> GetAllAsync(int page, int pageSize);
        Task<Author?> GetByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
    }
}