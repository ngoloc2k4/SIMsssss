namespace SIM_Project.Models
{
    public class Programmer
    {
        public int ProgrammerID { get; set; }
        public string ProgramName { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
