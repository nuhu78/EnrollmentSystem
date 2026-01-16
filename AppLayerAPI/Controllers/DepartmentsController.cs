using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        DepartmentService service;

        public DepartmentsController(DataAccessFactoy daf)
        {
            service = new DepartmentService(daf);
        }

        // GET: api/departments
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET: api/departments/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST: api/departments
        [HttpPost]
        public IActionResult Create(DepartmentDTO dto)
        {
            return Ok(service.Add(dto));
        }

        // PUT: api/departments
        [HttpPut]
        public IActionResult Update(DepartmentDTO dto)
        {
            return Ok(service.Update(dto));
        }

        // DELETE: api/departments/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return service.Delete(id) ? Ok("Deleted") : NotFound();
        }

        // ANALYTICS
        [HttpGet("{id}/student-count")]
        public IActionResult StudentCount(int id)
        {
            return Ok(new
            {
                DepartmentId = id,
                TotalStudents = service.GetStudentCount(id)
            });
        }
    }
}
