using BookstoreApplication.Models;

namespace BookstoreApplication.Repositorys
{
    public interface IAwardRepository
    {
        Task<Award> AddAsync(Award award);
        Task<bool> DeleteAsync(int id);
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetByIdAsync(int id);
        Task<Award> UpdateAsync(Award award);
    }
}