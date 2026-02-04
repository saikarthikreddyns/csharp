using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainHire.Models
{
    [Table("employers")]
    public class Employer
    {
        [Key] public int Id { get; set; }
        [ForeignKey("User")]
        public int  UserId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string CompanySize { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyDescription { get; set; }
        public string HeadquartersLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredCommunication { get; set; }

        public string? CompanyLogoPath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public User? User { get; set; }
    }

}
