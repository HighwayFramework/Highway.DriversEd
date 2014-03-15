using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Mappings
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            HasRequired(x => x.Instructor).WithMany(x => x.CoursesTaught).WillCascadeOnDelete(true);
        }
    }
}