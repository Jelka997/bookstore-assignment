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
        public IActionResult GetAll()
        {
            List<Publisher> publishers = publisherRepository.GetAll();
            return Ok(publishers);
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var publisher = publisherRepository.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST api/publishers
        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            return Ok(publisherRepository.Add(publisher));
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            var existingPublisher = publisherRepository.GetById(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }

            existingPublisher.Name = publisher.Name;
            existingPublisher.Address = publisher.Address;
            existingPublisher.Website = publisher.Website;
            var updatedPublisher = publisherRepository.Update(existingPublisher);
            return Ok(updatedPublisher);
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = publisherRepository.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            publisherRepository.Delete(id);

            return NoContent();
        }
    }
}
