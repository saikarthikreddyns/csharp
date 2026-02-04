using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainHire.Data;
using TrainHire.Models;

namespace TrainHire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // ✅ GET user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // ✅ POST (Create new user)
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User created successfully", user });
        }

        // ✅ PUT (Update existing user)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("User not found");

            user.Email = updatedUser.Email;
            user.UserType = updatedUser.UserType;
            user.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(new { message = "User updated successfully", user });
        }

        // ✅ DELETE user
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User deleted successfully");
        }
    }
}
