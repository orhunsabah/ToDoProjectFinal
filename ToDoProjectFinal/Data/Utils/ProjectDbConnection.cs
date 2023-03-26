using System.Data;

namespace ToDoProjectFinal.Data.Utils
{
    public interface IProjectDbConnection
    {
        IDbConnection GetConnection();
    }
    public class ProjectDbConnection : IProjectDbConnection
    {
        private readonly string _connectionString;

        public ProjectDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(_connectionString);
        }
    }

}
