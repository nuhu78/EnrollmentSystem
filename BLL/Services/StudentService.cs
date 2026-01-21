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
    public class StudentService
    {
        DataAccessFactoy daf;
       

        public StudentService(DataAccessFactoy daf)
        {
            this.daf = daf;
          
        }

        // CRUD
        public List<StudentDTO> GetAll()
        {
            var students = daf.StudentData().GetAll();
            return MapperConfig.GetMapper().Map<List<StudentDTO>>(students);
        }

        public StudentDTO Get(int id)
        {
            var student = daf.StudentData().Get(id);
            return MapperConfig.GetMapper().Map<StudentDTO>(student);
        }

        public StudentDTO Add(StudentDTO dto)
        {
            var department = daf.DepartmentData().Get(dto.DepartmentId);

            if (department == null)
                throw new Exception("Invalid  Department");

            var student = MapperConfig.GetMapper().Map<Student>(dto);

            // BUSINESS RULE: Auto status set
            student.Status = student.Cgpa < 2.0 ? "Probation" : "Active";

            var saved = daf.StudentData().Add(student);
            return MapperConfig.GetMapper().Map<StudentDTO>(saved);
        }

        public StudentDTO Update(StudentDTO dto)
        {
            var department = daf.DepartmentData().Get(dto.DepartmentId);

            if (department == null)
                throw new Exception("Invalid  Department");

            var student = MapperConfig.GetMapper().Map<Student>(dto);

            // BUSINESS RULE: Auto status update
            student.Status = student.Cgpa < 2.0 ? "Probation" : "Active";

            var updated = daf.StudentData().Update(student);
            return MapperConfig.GetMapper().Map<StudentDTO>(updated);
        }

        public bool Delete(int id)
        {
            return daf.StudentData().Delete(id);
        }

        // NON-CRUD FEATURES

        public List<StudentDTO> Search(string? name, int? departmentId, int? studentId)
        {
            var students = daf.StudentData().Search(name, departmentId, studentId); 
            return MapperConfig.GetMapper().Map<List<StudentDTO>>(students);
        }

        public List<StudentDTO> GetTopStudents(int count)
        {
            var students = daf.StudentData().GetTopStudents(count);
            return MapperConfig.GetMapper().Map<List<StudentDTO>>(students);
        }
    }
}
