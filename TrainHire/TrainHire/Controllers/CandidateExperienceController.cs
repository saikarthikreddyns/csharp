using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainHire.Data;
using TrainHire.Models;
using Microsoft.AspNetCore.Authorization;

namespace TrainHire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CandidateExperienceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidateExperienceController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all experience records
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var experiences = await _context.CandidateExperiences
                .Include(e => e.Candidate)
                .ToListAsync();

            return Ok(experiences);
        }

        // ✅ GET experience records by Candidate ID
        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetByCandidateId(int candidateId)
        {
            var experiences = await _context.CandidateExperiences
                .Where(e => e.CandidateId == candidateId)
                .Include(e => e.Candidate)
                .ToListAsync();

            return Ok(experiences);
        }

        // ✅ GET experience by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var experience = await _context.CandidateExperiences
                .Include(e => e.Candidate)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (experience == null)
                return NotFound("Experience record not found");

            return Ok(experience);
        }

        // ✅ POST (Create new experience record)
        [HttpPost]
        public async Task<IActionResult> Create(CandidateExperience experience)
        {
            // Verify candidate exists
            var candidateExists = await _context.Candidates.AnyAsync(c => c.Id == experience.CandidateId);
            if (!candidateExists)
                return BadRequest("Candidate not found");

            _context.CandidateExperiences.Add(experience);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Experience record created successfully", experience });
        }

        // ✅ PUT (Update existing experience record)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CandidateExperience updatedExperience)
        {
            var experience = await _context.CandidateExperiences.FindAsync(id);
            if (experience == null)
                return NotFound("Experience record not found");

            experience.JobTitle = updatedExperience.JobTitle;
            experience.Company = updatedExperience.Company;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;
            experience.Description = updatedExperience.Description;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Experience record updated successfully", experience });
        }

        // ✅ DELETE (Remove experience record)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _context.CandidateExperiences.FindAsync(id);
            if (experience == null)
                return NotFound("Experience record not found");

            _context.CandidateExperiences.Remove(experience);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Experience record deleted successfully" });
        }
    }
}