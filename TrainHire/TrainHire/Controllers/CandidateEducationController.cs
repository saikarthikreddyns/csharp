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
    public class CandidateEducationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidateEducationController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all education records
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var educations = await _context.CandidateEducations
                .Include(e => e.Candidate)
                .ToListAsync();

            return Ok(educations);
        }

        // ✅ GET education records by Candidate ID
        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetByCandidateId(int candidateId)
        {
            var educations = await _context.CandidateEducations
                .Where(e => e.CandidateId == candidateId)
                .Include(e => e.Candidate)
                .ToListAsync();

            return Ok(educations);
        }

        // ✅ GET education by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var education = await _context.CandidateEducations
                .Include(e => e.Candidate)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (education == null)
                return NotFound("Education record not found");

            return Ok(education);
        }

        // ✅ POST (Create new education record)
        [HttpPost]
        public async Task<IActionResult> Create(CandidateEducation education)
        {
            // Verify candidate exists
            var candidateExists = await _context.Candidates.AnyAsync(c => c.Id == education.CandidateId);
            if (!candidateExists)
                return BadRequest("Candidate not found");

            _context.CandidateEducations.Add(education);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Education record created successfully", education });
        }

        // ✅ PUT (Update existing education record)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CandidateEducation updatedEducation)
        {
            var education = await _context.CandidateEducations.FindAsync(id);
            if (education == null)
                return NotFound("Education record not found");

            education.Degree = updatedEducation.Degree;
            education.Major = updatedEducation.Major;
            education.University = updatedEducation.University;
            education.GraduationYear = updatedEducation.GraduationYear;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Education record updated successfully", education });
        }

        // ✅ DELETE (Remove education record)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _context.CandidateEducations.FindAsync(id);
            if (education == null)
                return NotFound("Education record not found");

            _context.CandidateEducations.Remove(education);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Education record deleted successfully" });
        }
    }
}