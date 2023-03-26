using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IInsertSubToDoDataRequest
    {
        Task<bool> InsertSubToDo(InsertSubToDoDataModel model);
    }
    public class InsertSubToDoDataRequest : IInsertSubToDoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public InsertSubToDoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertSubToDo(InsertSubToDoDataModel model)
        {
            var query = "INSERT INTO SubToDo(Title,IsDone,EffectPercentage,ToDoId) VALUES(@Title,@IsDone,@EffectPercentage,@ToDoId)";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}
