using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IDeleteToDoByIdDataRequest
    {
        Task<bool> DeleteToDoById(int id);
    }
    public class DeleteToDoByIdDataRequest : IDeleteToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public DeleteToDoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteToDoById(int id)
        {
            var query = $"DELETE FROM ToDo WHERE Id={id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query) ;
            return response > 0;
        }
    }
}
