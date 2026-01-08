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
        public async Task<IActionResult> GetAllAsync()
        {
            List<Award> awards = await awardRepository.GetAllAsync();
            return Ok(awards);
        }

        // GET api/awards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var award = await awardRepository.GetByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }

        // POST api/award
        [HttpPost]
        public async Task<IActionResult> PostAsync(Award award)
        {
            return Ok(await awardRepository.AddAsync(award));
        }

        // PUT api/award/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest();
            }

            var existingAward = await awardRepository.GetByIdAsync(id);
            if (existingAward == null)
            {
                return NotFound();
            }

            existingAward.Name = award.Name;
            existingAward.Year = award.Year;
            existingAward.Description = award.Description;
            var updatedAward = await awardRepository.UpdateAsync(existingAward);
            return Ok(updatedAward);
        }

        // DELETE api/awards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var award = await awardRepository.GetByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            await awardRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
