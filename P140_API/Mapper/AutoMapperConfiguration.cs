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
                .ForMember(d=>d.Date,opt=>opt.MapFrom(t=>t.Date.ToString("dddd MMMM")));

            CreateMap<StudentAttendance, StudentAttendanceDTO>()
                .ForMember(d => d.Attendance, opt => opt.MapFrom(t => ((AttendanceType)t.Attendance).ToString()))
                .ForMember(d => d.Date, opt => opt.MapFrom(t => t.Date.ToString("dddd MMMM")));

            CreateMap<GroupCreateDTO, Group>()
                .ForMember(gcd=>gcd.IsActive,opt=>opt.MapFrom(t=>true))
                .ForMember(gcd=>gcd.CreatedAt,opt=>opt.MapFrom(t=>DateTime.Now))
                .ForMember(gcd=>gcd.ModifiedAt,opt=>opt.MapFrom(t=> DateTime.Now));
            #region Logic
            //Name=> ..... = Name
            //Profession=> .... = Profession
            //IsActive=> ..... X
            #endregion
            //dd MMMM yyyy
        }
    }
}
