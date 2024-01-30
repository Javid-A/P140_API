using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using P140_API.DAL;
using P140_API.DTOs;
using P140_API.Entities;
using P140_API.Helpers.Attendances;

namespace P140_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public GroupsController(AcademyDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Group> groups = _context.Groups.Include(g=>g.StudentAttendances).ThenInclude(sa=>sa.Student)
                                                .Include(g=>g.TeacherAttendances).ThenInclude(ta =>ta.Teacher)
                                                .Where(g=>g.IsActive).AsNoTracking().ToList();
            List<GroupGetDTO> dto = _mapper.Map<List<GroupGetDTO>>(groups);
            return Ok(dto);
            //return  Ok(new
            //{
            //    StatusCode=200,
            //    Groups = groups.Select(g => new
            //    {
            //        g.Name,
            //        g.Profession,
            //        StudentAttendances = g.StudentAttendances.Select(sa => new
            //        {
            //            sa.Student.Fullname,
            //            Attendance= ((AttendanceType)sa.Attendance).ToString(),
            //            sa.Date
            //        }).ToList(),
            //        TeacherAttendances = g.TeacherAttendances.Select(ta => new
            //        {
            //            ta.Teacher.Fullname,
            //            Attendance= ((AttendanceType)ta.Attendance).ToString(),
            //            ta.Date
            //        }).ToList(),
            //        g.CreatedAt
            //    })
            //});
        }
        [HttpGet("get/{id}")]
        //[Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Group group = _context.Groups.Include(g => g.StudentAttendances).ThenInclude(sa => sa.Student)
                                                .Include(g => g.TeacherAttendances).ThenInclude(ta => ta.Teacher)
                                                .AsNoTracking().FirstOrDefault(g=>g.Id == id)!;
            GroupGetDTO dto = _mapper.Map<GroupGetDTO>(group);
            if (group is null) return NotFound();
            return Ok(dto);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]GroupCreateDTO group)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values.SelectMany(m=>m.Errors).ToList()
                });
            }
            //Group newGroup = new Group
            //{
            //    Name = group.Name,
            //    Profession = group.Profession,
            //    IsActive = true,
            //    CreatedAt = DateTime.Now,
            //    ModifiedAt = DateTime.Now
            //};
            Group newGroup = _mapper.Map<Group>(group);
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
