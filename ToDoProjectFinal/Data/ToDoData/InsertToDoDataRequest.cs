using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IInsertToDoDataRequest
    {
        Task<bool> InsertToDo(InsertToDoDataModel model);
    }
    public class InsertToDoDataRequest : IInsertToDoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public InsertToDoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertToDo(InsertToDoDataModel model)
        {
            var query = "INSERT INTO ToDo(Title,Progress,IsDone,UserId) VALUES(@Title,@Progress,@IsDone,@UserId)";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}
