using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseService service;

        public CoursesController(DataAccessFactoy daf)
        {
            service = new CourseService(daf);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(CourseDTO dto)
        {
            try
            {
                return Ok(service.Add(dto));
            }
            catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(CourseDTO dto)
        {
            try
            {
                return Ok(service.Update(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return service.Delete(id) ? Ok("Deleted") : NotFound();
        }
    }
}
