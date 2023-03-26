using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetSubToDoByIdDataRequest
    {
        Task<GetSubToDoDataModel> GetSubToDoById(int id);
    }
    public class GetSubToDoByIdDataRequest : IGetSubToDoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetSubToDoByIdDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetSubToDoDataModel> GetSubToDoById(int id)
        {
            var query = $"SELECT * FROM SubToDo WHERE Id = {id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetSubToDoDataModel>(query);
            return response;
        }
    }

    
}
