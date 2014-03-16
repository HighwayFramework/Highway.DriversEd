using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Domain.Entities;
using Highway.Data;

namespace Data.Queries
{
    public class DeleteCourse : AdvancedCommand
    {
        public DeleteCourse(int courseId)
        {
            ContextQuery = c =>
            {
                c.ExecuteSqlCommand("DELETE FROM Courses WHERE Id = @id",
                        new DbParameter[] {new SqlParameter("id", courseId)});
            };
        }
    }
}