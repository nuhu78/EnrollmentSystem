using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }

        public Department()
        {
            Students = new List<Student>();
            Courses = new List<Course>();

        }
    }
}
