using System.Linq;
using Domain.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class InstructorsByCourseCount : Query<Instructor>
    {
        public InstructorsByCourseCount(int numberOfClasses)
        {
            ContextQuery = c => c.AsQueryable<Instructor>()
                .Where(x => x.CoursesTaught.Count > numberOfClasses);
        } 
    }
}