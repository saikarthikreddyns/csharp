using Microsoft.EntityFrameworkCore;
using TrainHire.Models;

namespace TrainHire.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<CandidateEducation> CandidateEducations { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map to existing MySQL table names
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Candidate>().ToTable("candidates");
            modelBuilder.Entity<Employer>().ToTable("employers");
            modelBuilder.Entity<CandidateEducation>().ToTable("candidate_education");
            modelBuilder.Entity<CandidateExperience>().ToTable("candidate_experience");

            // Define relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Candidate)
                .WithOne(c => c.User)
                .HasForeignKey<Candidate>(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employer)
                .WithOne(e => e.User)
                .HasForeignKey<Employer>(e => e.UserId);

            modelBuilder.Entity<Candidate>()
               .HasMany<CandidateEducation>()
               .WithOne(e => e.Candidate)
               .HasForeignKey(e => e.CandidateId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
                .HasMany<CandidateExperience>()
                .WithOne(e => e.Candidate)
                .HasForeignKey(e => e.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
