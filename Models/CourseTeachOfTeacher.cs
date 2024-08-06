namespace SIM_Project.Models
{
    public class CourseTeachOfTeacher
    {
        public int CourseTeachOfTeacherID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
