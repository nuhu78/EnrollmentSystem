using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
     

        public string Code { get; set; }
      
        public int MaxCapacity { get; set; }
        public int DepartmentId { get; set; }
    }
}
