using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        // MAKE THIS NULLABLE
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public string Status { get; set; }
    }
}
