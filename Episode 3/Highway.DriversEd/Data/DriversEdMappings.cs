using System.Data.Entity;
using Data.Mappings;
using Highway.Data;

namespace Data
{
    public class DriversEdMappings : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InstructorMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new CourseGradeMap());

        }
    }
}