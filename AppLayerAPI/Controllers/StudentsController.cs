using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentService service;

        public StudentsController(DataAccessFactoy daf)
        {
            service = new StudentService(daf);
        }
        // GET: api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = service.Get(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        // POST: api/students
        [HttpPost]
        public IActionResult Create(StudentDTO dto)
        {
            try
            {
                var result = service.Add(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
          
        }

        // PUT: api/students
        [HttpPut]
        public IActionResult Update(StudentDTO dto)
        {
            try
            {
                var result = service.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
          
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = service.Delete(id);
            return success ? Ok("Deleted") : NotFound();
        
         }

        // NON-CRUD: SEARCH
        // GET: api/students/search?name=Ali&departmentId=1&minCgpa=3.0
        [HttpGet("search")]
        public IActionResult Search(
      string? name,
      int? departmentId,
      int? studentId)
        {
            return Ok(service.Search(name, departmentId, studentId));
        }

        // NON-CRUD: SEARCH
        // GET: api/students/top/5
        [HttpGet("top/{count}")]
        public IActionResult TopStudents(int count)
        {
            return Ok(service.GetTopStudents(count));
        }


    }
}
