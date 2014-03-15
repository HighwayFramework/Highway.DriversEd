namespace Domain.Entities
{
    public class CourseGrade
    {
        public Student Student { get; set; }
        public Course Course { get; set; }

        public int Score { get; set; }
        
    }
}