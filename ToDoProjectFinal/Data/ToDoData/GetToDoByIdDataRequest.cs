using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IGetToDoByIdDataRequest
    {
        Task<GetToDoDataModel> GetToDoById(int id);
    }
    public class GetToDoByIdDataRequest : IGetToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetToDoByIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetToDoDataModel> GetToDoById(int id)
        {
            var query = $"SELECT * FROM ToDo WHERE Id={id}";
            var conn = _dbConnection.GetConnection();

            var response = await conn.QueryFirstOrDefaultAsync<GetToDoDataModel>(query);

            return response;
        }

    }
}
