using Microsoft.EntityFrameworkCore;
using Bài_TH_01.Models;

namespace Bài_TH_01.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options) { }

        // make DbSet properties nullable to satisfy nullable-analysis
        public virtual DbSet<Course>? Courses { get; set; }
        public virtual DbSet<Learner>? Learners { get; set; }
        public virtual DbSet<Enrollment>? Enrollments { get; set; }
        public virtual DbSet<Major>? Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>().ToTable(nameof(Major));
            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<Learner>().ToTable(nameof(Learner));
            modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));
        }
    }
}
