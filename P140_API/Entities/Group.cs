namespace P140_API.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<StudentAttendance> StudentAttendances { get; set; }
        public List<TeacherAttendance> TeacherAttendances { get; set; }
    }
}
