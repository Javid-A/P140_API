namespace P140_API.DTOs
{
    public class CreateStudentAttendanceDTO
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
    }
}
