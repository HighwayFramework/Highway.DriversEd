using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Mappings
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasMany(x => x.Scores).WithRequired(x => x.Student).WillCascadeOnDelete(true);
        }
    }
}