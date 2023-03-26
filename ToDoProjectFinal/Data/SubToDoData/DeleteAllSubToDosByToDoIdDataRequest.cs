using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IDeleteAllSubToDosByToDoIdDataRequest
    {
        Task<bool> DeleteAllSubToDosByToDoId(int ToDoId);
    }
    public class DeleteAllSubToDosByToDoIdDataRequest : IDeleteAllSubToDosByToDoIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public DeleteAllSubToDosByToDoIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteAllSubToDosByToDoId(int ToDoId)
        {
            var query = $"DELETE FROM SubToDo WHERE ToDoId = {ToDoId}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
