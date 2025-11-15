namespace TH1_lms.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }
        public Course? Course { get; set; }

        public int LearnerID { get; set; }
        public Learner? Learner { get; set; }

        public float Grade { get; set; }
    }
}
