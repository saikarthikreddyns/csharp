using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TrainHire.Models
{
    [Table("candidates")]
    public class Candidate
    {
        [Key] public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string JobTitle {  get; set; }

        public string Location { get; set; }
        public string DesiredJobType { get; set; }

        public string? TechnicalSkills { get; set; }
        public string? SoftSkills { get; set; }
        public string? AreaOfIntrest { get; set; }
        public string? ResumeFilePath { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GithubUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }

    }
}
