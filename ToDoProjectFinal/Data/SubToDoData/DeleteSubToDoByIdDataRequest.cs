using System.Reflection.Metadata.Ecma335;
using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IDeleteSubToDoByIdDataRequest
    {
        Task<bool> DeleteSubToDoById(int id);
    }
    public class DeleteSubToDoByIdDataRequest : IDeleteSubToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public DeleteSubToDoByIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteSubToDoById(int id)
        {
            var query = $"DELETE FROM SubToDo WHERE Id={id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
