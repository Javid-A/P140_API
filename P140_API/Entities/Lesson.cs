namespace P140_API.Entities
{
    public class Lesson:BaseEntity
    {
        public DateTime StartDate { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int Attendance { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
    }
}
