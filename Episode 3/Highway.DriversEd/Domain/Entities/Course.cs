using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course : Entity
    {
        public ICollection<Driver> Students { get; set; }
        public Instructor Instructor { get; set; }
        public string Name { get; set; }
    }
}