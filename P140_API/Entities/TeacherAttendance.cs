using System.Reflection.Metadata.Ecma335;

namespace P140_API.Entities
{
    public class TeacherAttendance:BaseEntity
    {
        public int GroupId { get; set; }
        public int Attendance { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public Group Group { get; set; } = null!;
    }
}
