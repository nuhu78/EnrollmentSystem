using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Cgpa { get; set; }
        public string Status { get; set; }

        // EF automatically treats this as FK
        public int DepartmentId { get; set; }

        // Navigation
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
