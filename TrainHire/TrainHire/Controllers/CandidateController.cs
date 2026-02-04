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
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidateController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all candidates
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidates = await _context.Candidates
                .Include(c => c.User) // joins user data
                .ToListAsync();

            return Ok(candidates);
        }

        // ✅ GET candidate by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidate = await _context.Candidates
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
                return NotFound("Candidate not found");

            return Ok(candidate);
        }

        // ✅ POST (Create new candidate)
        [HttpPost]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            candidate.CreatedAt = DateTime.UtcNow;
            candidate.ModifiedAt = DateTime.UtcNow;

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Candidate created successfully", candidate });
        }

        // ✅ PUT (Update existing candidate)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Candidate updatedCandidate)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
                return NotFound("Candidate not found");

            // 🔄 Update only the allowed fields
            candidate.FirstName = updatedCandidate.FirstName;
            candidate.LastName = updatedCandidate.LastName;
            candidate.JobTitle = updatedCandidate.JobTitle;
            candidate.Location = updatedCandidate.Location;
            candidate.DesiredJobType = updatedCandidate.DesiredJobType;
            candidate.TechnicalSkills = updatedCandidate.TechnicalSkills;
            candidate.SoftSkills = updatedCandidate.SoftSkills;
            candidate.AreaOfIntrest = updatedCandidate.AreaOfIntrest;
            candidate.LinkedInUrl = updatedCandidate.LinkedInUrl;
            candidate.GithubUrl = updatedCandidate.GithubUrl;
            candidate.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Candidate updated successfully", candidate });
        }

        // ✅ DELETE (Remove candidate)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
                return NotFound("Candidate not found");

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Candidate deleted successfully" });
        }
    }
}
