using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainHire.Models
{
    [Table("candidate_education")]
    public class CandidateEducation
    {
        [Key] public int Id { get; set; }

        [ForeignKey("candidate")]
        public int CandidateId { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public int GraduationYear { get; set; }

        public Candidate? Candidate { get; set; }
    }
}
