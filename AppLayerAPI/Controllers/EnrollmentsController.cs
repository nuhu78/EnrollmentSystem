using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        EnrollmentService service;

        public EnrollmentsController(DataAccessFactoy daf)
        {
            service = new EnrollmentService(daf);
        }

        // POST: api/enrollments
        [HttpPost]
        public IActionResult Enroll([FromBody] EnrollmentDTO dto)
        {
            try
            {
                var result = service.EnrollStudent(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("drop")]
        public IActionResult DropCourse(int studentId, int courseId)
        {
            try
            {
                var result = service.DropCourse(studentId, courseId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
