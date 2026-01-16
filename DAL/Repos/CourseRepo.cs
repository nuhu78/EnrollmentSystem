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
    internal class CourseRepo : Repository<Course>, ICourseRepository
    {
        public CourseRepo(UMSContext db) : base(db) { }
    }
}
