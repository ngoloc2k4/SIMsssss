namespace SIM_Project.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProgrammerID { get; set; }
        public Programmer Programmer { get; set; }
        public ICollection<CourseLearningOfStudent> CourseLearnings { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
