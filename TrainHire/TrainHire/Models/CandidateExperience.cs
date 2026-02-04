using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainHire.Models
{
    [Table("candidate_experience")]
    public class CandidateExperience
    {
        [Key] public int Id { get; set; }

        [ForeignKey("candidate")]
        public int CandidateId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string StartDate { get; set; }

        public string? EndDate { get; set; }

        public string? Description { get; set; }

        public Candidate? Candidate { get; set; }
    }
}
