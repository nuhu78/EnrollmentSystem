using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EnrollmentRepo : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepo(UMSContext db) : base(db)
        {
        }

        public int CountByCourse(int courseId)
        {
            return db.Enrollments.Count(e => e.CourseId == courseId && e.Status== "Enrolled");
        }

        public bool Exists(int studentId, int courseId)
        {
            return db.Enrollments.Any(e =>
      e.StudentId == studentId &&
      e.CourseId == courseId &&
      e.Status != "Dropped");
        }

        public Enrollment GetActiveEnrollment(int studentId, int courseId)
        {
            return db.Enrollments.FirstOrDefault(e =>
        e.StudentId == studentId &&
        e.CourseId == courseId &&
        e.Status != "Dropped");
        }

        public int GetCourseCapacity(int courseId)
        {
            return db.Courses
                    .Where(c => c.Id == courseId)
                    .Select(c => c.MaxCapacity)
                    .FirstOrDefault();
        }


    }
}
