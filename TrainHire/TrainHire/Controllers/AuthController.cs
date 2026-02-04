using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainHire.Data;
using TrainHire.Models;
using Microsoft.EntityFrameworkCore;

namespace TrainHire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _passwordHasher = new PasswordHasher<User>();
        }

        // ✅ Register new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return BadRequest("User already exists");

            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.CreatedAt = DateTime.UtcNow;
            user.ModifiedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registration successful", user.Email });
        }

        // ✅ Login (returns JWT token)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid email or password");

            var token = GenerateJwtToken(user);
            return Ok(new { message = "Login successful", token });
        }

        // ✅ Generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("userId", user.Id.ToString()),
                new Claim("userType", user.UserType),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // ✅ Simple model for login request
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
