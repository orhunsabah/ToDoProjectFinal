using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetSumOfDoneSubToDosByToDoIdDataRequest
    {
        Task<int> GetSumOfDoneSubToDosByToDoId(int ToDoId);
    }
    public class GetSumOfDoneSubToDosByToDoIdDataRequest : IGetSumOfDoneSubToDosByToDoIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetSumOfDoneSubToDosByToDoIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetSumOfDoneSubToDosByToDoId(int ToDoId)
        {
            var query = $"SELECT SUM(EffectPercentage) FROM SubToDo WHERE ToDoId = {ToDoId} AND IsDone=1";
            var conn = _dbConnection.GetConnection();
            var response =await conn.ExecuteScalarAsync<int>(query);
            return response;
        }
    }
}
