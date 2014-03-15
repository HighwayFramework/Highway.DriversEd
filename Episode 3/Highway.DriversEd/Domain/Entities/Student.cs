using System.Collections.Generic;

namespace Domain.Entities
{
    public class Student : Driver
    {
        public ICollection<CourseGrade> Scores { get; set; }
        

    }
}