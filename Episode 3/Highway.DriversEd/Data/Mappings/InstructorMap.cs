using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Mappings
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap()
        {
            HasMany(x => x.CoursesTaught).WithRequired(x => x.Instructor).WillCascadeOnDelete(true);
        }
    }
}