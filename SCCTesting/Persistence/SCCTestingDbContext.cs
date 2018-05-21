using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCCTesting.Models;

namespace SCCTesting.Persistence
{
    public class SCCTestingDbContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Student> Students { get; set; }


        public SCCTestingDbContext(DbContextOptions<SCCTestingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Professor Term Relation *********
            modelBuilder.Entity<ProfessorTerm>()
                .HasKey(t => new { t.ProfessorId, t.TermId });

            // ProfessorTerm Course Relation *********
            modelBuilder.Entity<ProfessorTermCourse>()
                .HasKey(t => new { t.ProfessorId, t.TermId, t.CourseId });

            // set Test Relation to ProfessorTermCourse 1-many
            modelBuilder.Entity<Test>()
                .HasOne(pt => pt.ProfessorTermCourse)
                .WithMany(p => p.Tests)
                .HasForeignKey(pt => new { pt.ProfessorId, pt.TermId, pt.CourseId })
                .OnDelete(DeleteBehavior.Restrict);

            // ProfessorTerm Course Relation *********
            modelBuilder.Entity<StudentTest>()
                .HasKey(t => new { t.StudentId, t.TestId });

        }
    }
}
