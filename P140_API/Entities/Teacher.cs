namespace P140_API.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
