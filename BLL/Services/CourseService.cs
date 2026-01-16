using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        DataAccessFactoy daf;
       

        public CourseService(DataAccessFactoy daf)
        {
            this.daf = daf;
            
        }

        public List<CourseDTO> GetAll()
        {
            var data = daf.CourseData().GetAll();
            return MapperConfig.GetMapper().Map<List<CourseDTO>>(data);
        }
        public CourseDTO Get(int id)
        {
            var data = daf.CourseData().Get(id);
            return MapperConfig.GetMapper().Map<CourseDTO>(data);
        }

        public CourseDTO Add(CourseDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<DAL.EF.Models.Course>(dto);
            var saved = daf.CourseData().Add(entity);
            return MapperConfig.GetMapper().Map<CourseDTO>(saved);
        }

        public CourseDTO Update(CourseDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<DAL.EF.Models.Course>(dto);
            var updated = daf.CourseData().Update(entity);
            return MapperConfig.GetMapper().Map<CourseDTO>(updated);
        }

        public bool Delete(int id)
        {
            return daf.CourseData().Delete(id);
        }
    }
}
