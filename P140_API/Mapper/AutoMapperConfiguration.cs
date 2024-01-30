using AutoMapper;
using P140_API.DTOs;
using P140_API.Entities;
using P140_API.Helpers.Attendances;

namespace P140_API.Mapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Group,GroupGetDTO>()
                .ForMember(ggd=> ggd.Ixtisas,opt=>opt.MapFrom(g=>g.Profession));

            CreateMap<TeacherAttendance, TeacherAttendanceDTO>()
                .ForMember(d=>d.Attendance,opt=>opt.MapFrom(t=> ((AttendanceType)t.Attendance).ToString()))
                .ForMember(d=>d.Date,opt=>opt.MapFrom(t=>t.Date.ToString("dd MMMM yyyy")));

            CreateMap<StudentAttendance, StudentAttendanceDTO>()
                .ForMember(d => d.Attendance, opt => opt.MapFrom(t => ((AttendanceType)t.Attendance).ToString()))
                .ForMember(d => d.Date, opt => opt.MapFrom(t => t.Date.ToString("dd MMMM yyyy")));

            CreateMap<GroupCreateDTO, Group>()
                .ForMember(gcd=>gcd.IsActive,opt=>opt.MapFrom(t=>true))
                .ForMember(gcd=>gcd.CreatedAt,opt=>opt.MapFrom(t=>DateTime.Now))
                .ForMember(gcd=>gcd.ModifiedAt,opt=>opt.MapFrom(t=> DateTime.Now));

            CreateMap<Student, StudentAttendanceGetDTO>()
                .ForMember(sa=>sa.StudentFullname,opt=>opt.MapFrom(s=>s.Fullname))
                .ForMember(sa=>sa.Attendances,opt=>opt.MapFrom(s=>s.StudentAttendances));

            CreateMap<StudentAttendance, AttendanceDTO>()
                .ForMember(d => d.Attendance, opt => opt.MapFrom(t => ((AttendanceType)t.Attendance).ToString()))
                .ForMember(d => d.Date, opt => opt.MapFrom(t => t.Date.ToString("dd MMMM yyyy")))
                .ForMember(d => d.TeacherName, opt => opt.MapFrom(t => t.Group.TeacherAttendances.First().Teacher.Fullname));

            CreateMap<CreateStudentAttendanceDTO, StudentAttendance>();
            #region Logic
            //Name=> ..... = Name
            //Profession=> .... = Profession
            //IsActive=> ..... X
            #endregion
            //dd MMMM yyyy
        }
    }
}
