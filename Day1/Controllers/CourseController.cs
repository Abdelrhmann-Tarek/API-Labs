using Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _context.Courses.ToListAsync();
            if (courses==null||courses.Count==0)  return NotFound();    
            return Ok(courses);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course==null) return NotFound();
            return Ok(course);
        }



    }
}
