using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly AwardRepository awardRepository;

        public AwardController(AwardRepository awardRepository)
        {
            this.awardRepository = awardRepository;
        }

        // GET: api/awards
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Award> awards = awardRepository.GetAll();
            return Ok(awards);
        }

        // GET api/awards/5
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var award = awardRepository.GetById(id);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }

        // POST api/award
        [HttpPost]
        public IActionResult Post(Award award)
        {
            return Ok(awardRepository.Add(award));
        }

        // PUT api/award/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest();
            }

            var existingAward = awardRepository.GetById(id);
            if (existingAward == null)
            {
                return NotFound();
            }

            existingAward.Name = award.Name;
            existingAward.Year = award.Year;
            existingAward.Description = award.Description;
            var updatedAward = awardRepository.Update(existingAward);
            return Ok(updatedAward);
        }

        // DELETE api/awards/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var award = awardRepository.GetById(id);
            if (award == null)
            {
                return NotFound();
            }
            awardRepository.Delete(id);

            return NoContent();
        }
    }
}
