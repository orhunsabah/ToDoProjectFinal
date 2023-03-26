using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IChangeProgressOfToDoDataRequest
    {
        Task<bool> ChangeProgressOfToDo(int ToDoId, int TotalProgressOfToDo);
    }
    public class ChangeProgressOfToDoDataRequest : IChangeProgressOfToDoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public ChangeProgressOfToDoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> ChangeProgressOfToDo(int ToDoId, int TotalProgressOfToDo)
        {
            var query = $"UPDATE ToDo SET Progress = {TotalProgressOfToDo} WHERE Id={ToDoId}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query) ;
            return response>0;
        }
    }
}
