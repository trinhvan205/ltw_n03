namespace TH1_lms.Models
{
    public class Major
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; } = string.Empty;

        // Navigation
        public ICollection<Learner> Learners { get; set; } = new List<Learner>();
    }
}
