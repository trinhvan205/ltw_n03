namespace TH1_lms.Models
{
    public class Course
    {
        public int CourseID { get; set; }   // Auto increment mặc định
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
