using System.Collections.Generic;
using Highway.Data;
using Highway.Data.EventManagement.Interfaces;

namespace Data
{
    public class DriverEd : IDomain
    {
        public DriverEd(string connectionString)
        {
            ConnectionString = connectionString;
            Mappings = new DriversEdMappings();
            Events = new List<IInterceptor>();
        }

        public string ConnectionString { get; private set; }
        public IMappingConfiguration Mappings { get; private set; }
        public IContextConfiguration Context { get; private set; }
        public List<IInterceptor> Events { get; private set; }
    }
}