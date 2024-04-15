using Microsoft.EntityFrameworkCore;
using StudentsGrades.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<GradeModel> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "StudentsGrades.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<GradeModel>().Property(e => e.Id).ValueGeneratedOnAdd();

            var grade = new GradeModel()
            {
                Id = 1,
                Subject = "Math",
                Value = 5,
                Year = new DateTime(2023, 4, 15),
                StudentId = 1,

            };
            modelBuilder.Entity<GradeModel>().HasData(grade);

            var student  = new StudentModel()
            {
                Id = 1,
                FirstName = "Lily",
                LastName = "Ivanova",
                FacultyNumber = "121221023",
               

            };
           
            modelBuilder.Entity<StudentModel>()
                .HasData(student);

            modelBuilder.Entity<StudentModel>()
             .HasMany(s => s.Grades)
             .WithOne(g => g.Student)
             .HasForeignKey(g => g.StudentId)
             .IsRequired();




        }

    }
}
