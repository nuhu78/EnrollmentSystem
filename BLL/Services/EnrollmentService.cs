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
    public class EnrollmentService
    {
        DataAccessFactoy daf;
      

        public EnrollmentService(DataAccessFactoy daf)
        {
            this.daf = daf;
          
        }

        public EnrollmentDTO EnrollStudent(EnrollmentDTO dto)
        {
            var enrollment = MapperConfig.GetMapper().Map<Enrollment>(dto);

            int enrolled = daf.EnrollmentData().CountByCourse(dto.CourseId);
            int capacity = daf.EnrollmentData().GetCourseCapacity(dto.CourseId);

            // 1️⃣ Validate Student
            var student = daf.StudentData().Get(dto.StudentId);
            if (student == null)
                throw new Exception("Student not found");
            // 2️⃣ Validate Course
            var course = daf.CourseData().Get(dto.CourseId);
            if (course == null)
                throw new Exception("Course not found");

            // 3️⃣ CGPA Rule
            if (student.Cgpa < 2.0)
                throw new Exception("Student CGPA too low for enrollment");

            // 4️⃣ Duplicate Enrollment Check
            if (daf.EnrollmentData().Exists(dto.StudentId, dto.CourseId))
                throw new Exception("Student already enrolled in this course");

            if (enrolled >= capacity)
            {
                
                return MapperConfig.GetMapper().Map<EnrollmentDTO>(enrollment);
            }



            enrollment.Status = "Enrolled";

            var saved = daf.EnrollmentData().Add(enrollment);
            return MapperConfig.GetMapper().Map<EnrollmentDTO>(saved);
        }

        public EnrollmentDTO DropCourse(int studentId, int courseId)
        {
            var enrollment = daf.EnrollmentData()
                                .GetActiveEnrollment(studentId, courseId);

            if (enrollment == null)
                throw new Exception("Active enrollment not found");

            enrollment.Status = "Dropped";

            var updated = daf.EnrollmentData().Update(enrollment);
            return MapperConfig.GetMapper().Map<EnrollmentDTO>(updated);
        }

    }
}
