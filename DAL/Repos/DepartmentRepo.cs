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
    public class DepartmentRepo : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepo(UMSContext db) : base(db)
        {
        }

        public int GetStudentCount(int departmentId)
        {
            return db.Students
                    .Count(s => s.DepartmentId == departmentId);
        }
    }
}
