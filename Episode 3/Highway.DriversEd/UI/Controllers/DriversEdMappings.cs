using System.Data.Entity;
using Data.Mappings;
using Highway.Data;

namespace UI.Controllers
{
    public class DriversEdMappings : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new InstructorMap());
            modelBuilder.Configurations.Add(new StudentMap());

        }
    }
}