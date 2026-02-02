using BookstoreApplication.Exceptions;
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
            if(award == null)
            {
                throw new BadRequestException("Invalid data.");
            }
            return await _awardRepository.AddAsync(award);
        }

        public async Task<Award> UpdateAsync(int id, Award award)
        {
            if (id != award.Id)
            {
                throw new BadRequestException("Identifier value is invalid.");
            }
            Award newAward = await _awardRepository.UpdateAsync(award);
            return newAward;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Award award = await _awardRepository.GetByIdAsync(id);
            if (award == null)
            {
                throw new NotFoundException(id);
            }
            return await _awardRepository.DeleteAsync(id);
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _awardRepository.GetAllAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            Award award = await _awardRepository.GetByIdAsync(id);
            if (award == null)
            {
                throw new NotFoundException(id);
            }
            return award;
        }
    }
}
