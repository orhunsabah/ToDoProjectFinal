using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetCountOfSubToDosByToDoIdDataRequest
    {
        Task<int> GetCountOfSubToDosByToDoId(int ToDoId);
    }
    public class GetCountOfSubToDosByToDoIdDataRequest : IGetCountOfSubToDosByToDoIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetCountOfSubToDosByToDoIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection= dbConnection;
        }

        public async Task<int> GetCountOfSubToDosByToDoId(int ToDoId)
        {
            var query = $"SELECT COUNT(Id) FROM SubToDo WHERE ToDoId={ToDoId}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteScalarAsync<int> (query);
            return response;
        }

    }
}
