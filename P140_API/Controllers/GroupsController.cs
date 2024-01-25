using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using P140_API.DAL;
using P140_API.DTOs;
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
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Group> groups = _context.Groups.Where(g=>g.IsActive).AsNoTracking().ToList();
            return  Ok(new
            {
                StatusCode=200,
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

        [HttpPost("create")]
        public IActionResult Create([FromBody]GroupCreateDTO group)
        {
            Group newGroup = new Group
            {
                Name = group.Name,
                Profession = group.Profession,
                IsActive = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            _context.Groups.Add(newGroup);
            _context.SaveChanges();

            return Ok(newGroup);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id,[FromBody]GroupUpdateDTO updatedGroup)
        {
            Group existed = _context.Groups.FirstOrDefault(g => g.Id == id)! ?? throw new NullReferenceException("Group is not found");
            existed.Name = updatedGroup.Name;
            existed.Profession = updatedGroup.Profession;
            existed.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok(updatedGroup);
        }

        [HttpPatch("changestatus/{id}")]
        public IActionResult UpdateStatus(int id)
        {
            Group existed = _context.Groups.FirstOrDefault(g => g.Id == id)! ?? throw new NullReferenceException("Group is not found");
            existed.IsActive = !existed.IsActive;
            existed.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok(existed);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Group group = _context.Groups.FirstOrDefault(g => g.Id == id)! ?? throw new NullReferenceException("Group is not found");
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return Ok(group);
        }

    }
}
