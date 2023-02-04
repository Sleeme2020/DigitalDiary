namespace DigitalDiary.Model
{
    public class Student:Human
    {
        public Parent Parent { get; set; }
        public Group Group { get; set; }
        public List<Presence> Presences { get; set; }
        public List<Mark> Marks { get; set; }
    }
}