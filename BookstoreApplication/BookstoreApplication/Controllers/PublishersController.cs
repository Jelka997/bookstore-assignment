using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository publisherRepository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        // GET: api/publishers
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Publisher> publishers = await publisherRepository.GetAllAsync();
            return Ok(publishers);
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var publisher = await publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST api/publishers
        [HttpPost]
        public async Task<IActionResult> PostAsync(Publisher publisher)
        {
            return Ok( await publisherRepository.AddAsync(publisher));
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            var existingPublisher = await publisherRepository.GetByIdAsync(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }

            existingPublisher.Name = publisher.Name;
            existingPublisher.Address = publisher.Address;
            existingPublisher.Website = publisher.Website;
            var updatedPublisher = await publisherRepository.UpdateAsync(existingPublisher);
            return Ok(updatedPublisher);
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var publisher =await publisherRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            await publisherRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
