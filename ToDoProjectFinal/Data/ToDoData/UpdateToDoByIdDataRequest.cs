using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IUpdateToDoByIdDataRequest
    {
        Task<bool> UpdateToDoById(InsertToDoDataModel model, int id);
    }
    public class UpdateToDoByIdDataRequest : IUpdateToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public UpdateToDoByIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateToDoById(InsertToDoDataModel model, int id)
        {
            var query = $"UPDATE ToDo SET Title=@Title,Progress=@Progress,IsDone=@IsDone,UserId=@UserId WHERE Id={id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}
