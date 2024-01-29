namespace P140_API.Entities
{
    public class Student:BaseEntity
    {
        //StudentFullname
        public string Fullname { get; set; }
        public List<StudentAttendance> StudentAttendances { get; set; }
    }
}
