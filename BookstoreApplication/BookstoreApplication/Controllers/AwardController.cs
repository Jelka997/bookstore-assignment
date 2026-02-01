using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly AwardService _awardService;

        public AwardController(AwardService awardService)
        {
            _awardService = awardService;
        }

        // GET: api/awards
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Award> awards = await _awardService.GetAllAsync();
            return Ok(awards);
        }

        // GET api/awards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var award = await _awardService.GetByIdAsync(id);
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
            return Ok(await _awardService.AddAsync(award));
        }

        // PUT api/award/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest();
            }

            var existingAward = await _awardService.GetByIdAsync(id);
            if (existingAward == null)
            {
                return NotFound();
            }

            existingAward.Name = award.Name;
            existingAward.Year = award.Year;
            existingAward.Description = award.Description;
            var updatedAward = await _awardService.UpdateAsync(existingAward);
            return Ok(updatedAward);
        }

        // DELETE api/awards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var award = await _awardService.GetByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            await _awardService.DeleteAsync(id);

            return NoContent();
        }
    }
}
