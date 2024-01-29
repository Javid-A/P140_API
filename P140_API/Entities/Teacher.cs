namespace P140_API.Entities
{
    public class Teacher:BaseEntity
    {
        public string Fullname { get; set; }
        public List<TeacherAttendance> TeacherAttendances { get; set; }
    }
}
