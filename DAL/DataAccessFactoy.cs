using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactoy
    {
        UMSContext db;
        public DataAccessFactoy(UMSContext db) {
            this.db = db;
        }
        public IStudentRepository StudentData()
        {
            return new StudentRepo(db);
        }

        public IEnrollmentRepository EnrollmentData()
        {
            return new EnrollmentRepo(db);
        }

        public IDepartmentRepository DepartmentData()
        {
            return new DepartmentRepo(db);
        }
        public ICourseRepository CourseData()
        {
            return new CourseRepo(db);
        }
    }
}
