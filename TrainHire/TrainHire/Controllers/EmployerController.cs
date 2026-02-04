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
    public class EmployerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployerController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all employers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employers = await _context.Employers
                .Include(e => e.User)
                .ToListAsync();

            return Ok(employers);
        }

        // ✅ GET employer by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employer = await _context.Employers
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employer == null)
                return NotFound("Employer not found");

            return Ok(employer);
        }

        // ✅ POST (Create)
        [HttpPost]
        public async Task<IActionResult> Create(Employer employer)
        {
            employer.CreatedAt = DateTime.UtcNow;
            employer.UpdatedAt = DateTime.UtcNow;

            _context.Employers.Add(employer);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employer created successfully", employer });
        }

        // ✅ PUT (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employer updatedEmployer)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
                return NotFound("Employer not found");

            employer.CompanyName = updatedEmployer.CompanyName;
            employer.ContactName = updatedEmployer.ContactName;
            employer.CompanySize = updatedEmployer.CompanySize;
            employer.CompanyWebsite = updatedEmployer.CompanyWebsite;
            employer.CompanyDescription = updatedEmployer.CompanyDescription;
            employer.HeadquartersLocation = updatedEmployer.HeadquartersLocation;
            employer.PhoneNumber = updatedEmployer.PhoneNumber;
            employer.PreferredCommunication = updatedEmployer.PreferredCommunication;
            employer.CompanyLogoPath = updatedEmployer.CompanyLogoPath;
            employer.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Employer updated successfully", employer });
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
                return NotFound("Employer not found");

            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employer deleted successfully" });
        }
    }
}
