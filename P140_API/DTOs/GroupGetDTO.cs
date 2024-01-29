using P140_API.Entities;

namespace P140_API.DTOs
{
    public class GroupGetDTO
    {
        public string Name { get; set; }
        public string Ixtisas { get; set; }
        public List<TeacherAttendanceDTO> TeacherAttendances { get; set; }
        public List<StudentAttendanceDTO> StudentAttendances { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
