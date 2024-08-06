namespace SIM_Project.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<CourseTeachOfTeacher> CourseTeachings { get; set; }
        public ICollection<CourseLearningOfStudent> CourseLearnings { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
