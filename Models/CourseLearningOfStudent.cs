namespace SIM_Project.Models
{
    public class CourseLearningOfStudent
    {
        public int CourseLearningOfStudentID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
