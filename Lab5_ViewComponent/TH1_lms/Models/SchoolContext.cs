using Microsoft.EntityFrameworkCore;

namespace TH1_lms.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Major> Majors => Set<Major>();
        public DbSet<Learner> Learners => Set<Learner>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API - Modern way
            modelBuilder.Entity<Major>()
                .HasMany(m => m.Learners)
                .WithOne(l => l.Major)
                .HasForeignKey(l => l.MajorID);

            modelBuilder.Entity<Learner>()
                .HasMany(l => l.Enrollments)
                .WithOne(e => e.Learner)
                .HasForeignKey(e => e.LearnerID);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseID);
        }
    }
}
