using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService
    {
        DataAccessFactoy daf;
     

        public DepartmentService(DataAccessFactoy daf)
        {
            this.daf = daf;
           
        }
       
        // CRUD
        public List<DepartmentDTO> GetAll()
        {
            var data = daf.DepartmentData().GetAll();
            return MapperConfig.GetMapper().Map<List<DepartmentDTO>>(data);
        }

        public DepartmentDTO Get(int id)
        {
            var data = daf.DepartmentData().Get(id);
            return MapperConfig.GetMapper().Map<DepartmentDTO>(data);
        }

        public DepartmentDTO Add(DepartmentDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<Department>(dto);
            var saved = daf.DepartmentData().Add(entity);
            return MapperConfig.GetMapper().Map<DepartmentDTO>(saved);
        }

        public DepartmentDTO Update(DepartmentDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<Department>(dto);
            var updated = daf.DepartmentData().Update(entity);
            return MapperConfig.GetMapper().Map<DepartmentDTO>(updated);
        }

        public bool Delete(int id)
        {
            return daf.DepartmentData().Delete(id);
        }

        // ANALYTICS FEATURE
        public int GetStudentCount(int departmentId)
        {
            return daf.DepartmentData().GetStudentCount(departmentId);
        }
    }
}
