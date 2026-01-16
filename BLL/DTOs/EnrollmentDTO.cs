using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? Status { get; set; }
    }
}
