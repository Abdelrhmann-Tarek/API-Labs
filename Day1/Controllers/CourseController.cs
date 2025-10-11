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
        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            if (course==null) return BadRequest();

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , Course course)
        {
            if(id != course.Id) return BadRequest();

            var existingCourse = await _context.Courses.FindAsync(course.Id);
            if (existingCourse==null) return NotFound();

            existingCourse.CrsName = course.CrsName;
            existingCourse.CrsDesc = course.CrsDesc;
            existingCourse.Duration = course.Duration;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }



    }
}
