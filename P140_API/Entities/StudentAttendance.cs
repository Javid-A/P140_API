namespace P140_API.Entities
{
    public class StudentAttendance:BaseEntity
    {
        public int GroupId { get; set; }
        public int Attendance { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; } = null!;
        public Group Group { get; set; } = null!;
    }
}
