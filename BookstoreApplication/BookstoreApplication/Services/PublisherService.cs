using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
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
            Publisher newPublisher = await _publisherRepository.AddAsync(publisher);
            return newPublisher;
        }

        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            Publisher newPublisher = await _publisherRepository.UpdateAsync(publisher);
            return publisher;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Publisher publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                return false;
            }

            return await _publisherRepository.DeleteAsync(id);
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }
    }
}
