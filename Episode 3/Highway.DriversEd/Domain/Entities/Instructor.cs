using System.Collections.Generic;

namespace Domain.Entities
{
    public class Instructor : Driver
    {
        public ICollection<Course> CoursesTaught { get; set; }
 
    }
}