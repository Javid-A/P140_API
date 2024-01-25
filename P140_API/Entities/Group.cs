namespace P140_API.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
