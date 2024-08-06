using System.Diagnostics;

namespace SIM_Project.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public int SemesterID { get; set; }
        public Semester Semester { get; set; }
        public int ProgrammerID { get; set; }
        public Programmer Programmer { get; set; }
        public ICollection<CourseTeachOfTeacher> CourseTeachings { get; set; }
        public ICollection<CourseLearningOfStudent> CourseLearnings { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
