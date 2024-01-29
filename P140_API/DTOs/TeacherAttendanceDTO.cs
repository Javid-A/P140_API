using P140_API.Entities;

namespace P140_API.DTOs
{
    public class TeacherAttendanceDTO
    {
        public string Attendance { get; set; }
        public string GroupName { get; set; }
        public string TeacherFullname { get; set; }
        public string Date { get; set; }
    }
}
