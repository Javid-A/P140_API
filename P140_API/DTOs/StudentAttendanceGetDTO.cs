namespace P140_API.DTOs
{
    public class StudentAttendanceGetDTO
    {
        public string StudentFullname { get; set; }
        public List<AttendanceDTO> Attendances { get; set; }
    }
}
