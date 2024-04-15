using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsGrades.Model
{
    public class GradeModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }
        public DateTime Year { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual StudentModel Student { get; set; }

    }
}
