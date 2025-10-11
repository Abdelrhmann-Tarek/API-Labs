using Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ApplicationDbContext db;
        public CourseController(ApplicationDbContext _db)
        {
            db = _db;
        }

        //[HttpGet]
        //public IActionResult getall()
        //{
        //    return db.Courses.ToList(); //////error
        //}
        
    }
}
