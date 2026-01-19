using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MaxCapacity { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }

        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}
