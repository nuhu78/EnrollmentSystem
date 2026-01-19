using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo : Repository<Student>, IStudentRepository
    {
        public StudentRepo(UMSContext db) : base(db) { }

        public List<Student> GetTopStudents(int count)
        {
            return db.Students
                  .OrderByDescending(s => s.Cgpa)
                  .Take(count)
                  .ToList();
        }

        public List<Student> Search(string? name, int? departmentId, int? studentId)
        {
            var query = db.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name.StartsWith(name));

            if (departmentId.HasValue)
                query = query.Where(s => s.DepartmentId == departmentId.Value);
            if (studentId.HasValue)
                query = query.Where(s => s.Id == studentId.Value);

            return query
                .Include(s => s.Department)
                .ToList();

        }
    }
}
