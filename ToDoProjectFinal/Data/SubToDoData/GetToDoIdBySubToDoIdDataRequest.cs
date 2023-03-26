using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetToDoIdBySubToDoIdDataRequest
    {
        Task<int> GetToDoIdBySubToDoId(int id);
    }
    public class GetToDoIdBySubToDoIdDataRequest : IGetToDoIdBySubToDoIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetToDoIdBySubToDoIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> GetToDoIdBySubToDoId(int id)
        {
            var query = $"SELECT ToDoId FROM SubToDo WHERE Id={id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteScalarAsync<int>(query);
            return response;
        }
    }
}
