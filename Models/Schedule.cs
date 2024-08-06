namespace SIM_Project.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public DateTime Date { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
