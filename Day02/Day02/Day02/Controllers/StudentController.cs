using AutoMapper;
using Day02.DTOs;
using Day02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        [HttpGet]
        public IActionResult Getall(int page = 1, int pageSize = 5, string? search = null)
        {
            IQueryable<Student> query = _context.Students;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.St_Fname.Contains(search) || s.St_Lname.Contains(search));
            }

            var students = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();  

            if (!students.Any())
                return NotFound();

            var studentDtos = _mapper.Map<IEnumerable<StudentDTO>>(students);

            return Ok(studentDtos);
        }




    }
}
