using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> Search(string name, int? departmentId, int? Id);
        List<Student> GetTopStudents(int count);
    }
}
