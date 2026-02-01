using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        public AwardService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }

        public async Task<Award> AddAsync(Award award)
        {
            Award newAward = await _awardRepository.AddAsync(award);
            return newAward;
        }

        public async Task<Award> UpdateAsync(Award award)
        {
            Award newAward = await _awardRepository.UpdateAsync(award);
            return newAward;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Award award = await _awardRepository.GetByIdAsync(id);
            if (award == null)
            {
                return false;
            }
            return await _awardRepository.DeleteAsync(id);
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _awardRepository.GetAllAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _awardRepository.GetByIdAsync(id);
        }
    }
}
