using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P140_API.DAL;
using P140_API.Entities;

namespace P140_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AcademyDbContext _context;

        public GroupsController(AcademyDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAll()
        {
            List<Group> groups = _context.Groups.AsNoTracking().ToList();
            return  Ok(new
            {
                StatusCode=500,
                Data = groups
            });
        }
        [HttpGet("get/{id}")]
        //[Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Group group = _context.Groups.AsNoTracking().FirstOrDefault(g=>g.Id == id);
            if (group is null) return NotFound();
            return Ok(group);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            Group group = _context.Groups.AsNoTracking().FirstOrDefault();
            return Ok(group);
        }

    }
}
