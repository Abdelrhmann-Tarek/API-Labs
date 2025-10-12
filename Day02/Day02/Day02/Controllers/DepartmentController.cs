using AutoMapper;
using Day02.DTOs;
using Day02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Getall()
        {
            var departments = _context.Departments.ToList();

            if (!departments.Any())
                return NotFound();

            var deptDtos = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);

            return Ok(deptDtos);
        }













    }
}
