using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {

        int CountByCourse(int courseId);

        int GetCourseCapacity(int courseId);

        Enrollment GetEnrollment(int studentId, int courseId);
    }
}
