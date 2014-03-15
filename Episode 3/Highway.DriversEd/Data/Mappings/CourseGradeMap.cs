using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Mappings
{
    public class CourseGradeMap : EntityTypeConfiguration<CourseGrade>
    {
        public CourseGradeMap()
        {
            HasRequired(x => x.Course).WithMany();
            HasRequired(x => x.Student).WithMany(x => x.Scores);
        }
    }
}