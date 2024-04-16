using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Model
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FacultyNumber { get; set; }
        public List<GradeModel> Grades { get; set; }
        public StudentModel() { 
            Grades = new List<GradeModel>();
        }

    }
}
