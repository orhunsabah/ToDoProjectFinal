using System.Reflection.Metadata.Ecma335;
using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetEffectPercentageOfSubToDoBySubToDoIdDataRequest
    {
        Task<int> GetEffectPercentageOfSubToDo(int SubToDoId);
    }
    public class GetEffectPercentageOfSubToDoBySubToDoIdDataRequest : IGetEffectPercentageOfSubToDoBySubToDoIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetEffectPercentageOfSubToDoBySubToDoIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetEffectPercentageOfSubToDo(int SubToDoId)
        {
            var query = $"SELECT EffectPercentage FROM SubToDo WHERE Id={SubToDoId}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteScalarAsync<int> (query);
            return response;
        }
    }
}
