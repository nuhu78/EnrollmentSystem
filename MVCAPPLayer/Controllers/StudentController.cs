using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCAPPLayer.Controllers
{
    public class StudentController : Controller
    {
        StudentService service;
        public StudentController(StudentService service) { 
            this.service = service;
        }
        public IActionResult Index()
        {
            
            var data = service.Get();
            return View(data);
        }
    }
}
