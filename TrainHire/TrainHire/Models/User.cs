using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainHire.Models
{
    [Table("users")]
    public class User
    {
        [Key] public int Id { get; set; }

        [Required] public string Email { get; set; } = string.Empty;
        [Required] public string PasswordHash { get; set; } = string.Empty;
        [Required] public string UserType { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        // ✅ Optional navigation properties
        public Candidate? Candidate { get; set; }
        public Employer? Employer { get; set; }
    }
}
