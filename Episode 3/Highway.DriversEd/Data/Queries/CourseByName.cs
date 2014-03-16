using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class CourseByName : Scalar<Course>
    {
        public CourseByName(string courseName)
        {
            ContextQuery = c => c.AsQueryable<Course>()
                .Include(x => x.Instructor)
                .SingleOrDefault(x => x.Name == courseName);
        }
    }
}