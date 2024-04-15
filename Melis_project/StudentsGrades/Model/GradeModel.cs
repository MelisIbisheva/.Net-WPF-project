using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsGrades.Model
{
    public class GradeModel
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Year { get; set; }
        public string Subject { get; set; }
        public int StudentId { get; set; } 
        public StudentModel Student { get; set; }
    }
}
