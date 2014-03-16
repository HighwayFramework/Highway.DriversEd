using System.Linq;
using Domain.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class AllCourses : Query<Course, string>
    {
        public AllCourses()
        {
            Selector = c => c.AsQueryable<Course>();
            Projector = courses => courses.Select(x => x.Name);
        }
    }
}