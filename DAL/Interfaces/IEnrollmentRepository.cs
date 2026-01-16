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
        bool Exists(int studentId, int courseId);
        int GetCourseCapacity(int courseId);

        Enrollment GetActiveEnrollment(int studentId, int courseId);
    }
}
