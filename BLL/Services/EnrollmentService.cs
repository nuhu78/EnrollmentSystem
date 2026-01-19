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
            if (enrolled >= capacity)
                throw new Exception("Course capacity is full");

            var existing = daf.EnrollmentData()
                               .GetEnrollment(dto.StudentId, dto.CourseId);
            if (existing != null)
            {
                if (existing.Status == "Enrolled")
                    throw new Exception("Student already enrolled in this course");
                if (existing.Status == "Completed")
                    throw new Exception("Student already Completed in this course");
                if (existing.Status == "Dropped")
                {
              
                    existing.Status = "Enrolled";
                    var updated = daf.EnrollmentData().Update(existing);
                    return MapperConfig.GetMapper().Map<EnrollmentDTO>(updated);
                }
            }

            var enrollment = MapperConfig.GetMapper().Map<Enrollment>(dto);
            enrollment.Status = "Enrolled";

            var saved = daf.EnrollmentData().Add(enrollment);
            return MapperConfig.GetMapper().Map<EnrollmentDTO>(saved);
        }

        public EnrollmentDTO DropCourse(int studentId, int courseId)
        {
            var enrollment = daf.EnrollmentData()
                                 .GetEnrollment(studentId, courseId);

            if (enrollment == null)
                throw new Exception("Enrollment not found");

            if (enrollment.Status == "Completed")
                throw new Exception("Cannot drop a course that is already Completed.");

            if (enrollment.Status == "Dropped")
                throw new Exception("You have already Dropped the Course.");

            enrollment.Status = "Dropped";

            var updated = daf.EnrollmentData().Update(enrollment);
            return MapperConfig.GetMapper().Map<EnrollmentDTO>(updated);
        }

        public EnrollmentDTO CompleteCourse(int studentId, int courseId)
        {
            var enrollment = daf.EnrollmentData()
                         .GetEnrollment(studentId, courseId);

            if (enrollment == null)
                throw new Exception("Enrollment not found");

            if (enrollment.Status == "Dropped")
                throw new Exception("Cannot complete a dropped course");

            if (enrollment.Status == "Completed")
                throw new Exception("You have already completed the course");

            enrollment.Status = "Completed";

            var updated = daf.EnrollmentData().Update(enrollment);
            return MapperConfig.GetMapper().Map<EnrollmentDTO>(updated);
        }



    }
}
