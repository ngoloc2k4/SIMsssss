namespace SIM_Project.Models
{
    public class Semester
    {
        public int SemesterID { get; set; }
        public string SemesterName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
