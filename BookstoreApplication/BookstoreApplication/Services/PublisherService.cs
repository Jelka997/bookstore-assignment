using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            if(publisher == null)
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _publisherRepository.AddAsync(publisher);
        }

        public async Task<Publisher> UpdateAsync(int id, Publisher publisher)
        {
            if (publisher.Id != id)
            {
                throw new BadRequestException("Identifier value is invalid.");
            }
            
            Publisher newPublisher = await _publisherRepository.UpdateAsync(publisher);
            return publisher;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                throw new NotFoundException(id);
            }
            return await _publisherRepository.DeleteAsync(id);
        }

        public async Task<List<Publisher>> GetAllAsync(string order, string orderDirection)
        {
            return await _publisherRepository.GetAllAsync(order, orderDirection);
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                throw new NotFoundException(id);
            }
            return publisher;
        }
    }
}
