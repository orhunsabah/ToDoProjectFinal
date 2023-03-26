using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IGetProgressOfToDoByIdDataRequest
    {
        Task<int> GetProgressOfToDoById(int Id);
    }
    public class GetProgressOfToDoByIdDataRequest : IGetProgressOfToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetProgressOfToDoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetProgressOfToDoById(int Id)
        {
            var query = $"SELECT Progress FROM ToDo Where Id = {Id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteScalarAsync<int>(query) ;
            return response;
        }
    }
}
