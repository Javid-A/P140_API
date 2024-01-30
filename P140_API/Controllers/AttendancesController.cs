using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P140_API.DAL;
using P140_API.DTOs;
using P140_API.Entities;
using P140_API.Exceptions;

namespace P140_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController:ControllerBase
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public AttendancesController(AcademyDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int groupId)
        {
            Group group = _context.Groups.FirstOrDefault(g => g.Id == groupId)!;
            if (group is null) throw new GroupIsNotFoundException("Group is not found");
            GroupGetDTO model = _mapper.Map<GroupGetDTO>(group);
            return Ok(model);
        }

        [HttpGet("getstudentattendances")]
        public IActionResult GetStudentAttendances(int studentId)
        {
            Student student = _context.Students.Include(s=>s.StudentAttendances)
                                                .ThenInclude(sa=>sa.Group)
                                                .ThenInclude(s=>s.TeacherAttendances)
                                                .ThenInclude(s=>s.Teacher).AsNoTracking().FirstOrDefault(s=>s.Id == studentId)!;
            if (student is null) throw new StudentIsNotFoundException("Student is not found");

            StudentAttendanceGetDTO model = _mapper.Map<StudentAttendanceGetDTO>(student);
            return Ok(model);
        }


        [HttpPost("create")]
        public IActionResult CreateStudentAttendance([FromBody]CreateStudentAttendanceDTO studentAttendance)
        {
            StudentAttendance attendance = _mapper.Map<StudentAttendance>(studentAttendance);
            _context.StudentAttendances.Add(attendance);
            _context.SaveChanges();
            return Ok(attendance.Id);
        }
    }
}
