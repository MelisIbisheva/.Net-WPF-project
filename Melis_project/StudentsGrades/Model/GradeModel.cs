using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsGrades.Model
{
    public class GradeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public int Year { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual StudentModel Student { get; set; }

    }
}
