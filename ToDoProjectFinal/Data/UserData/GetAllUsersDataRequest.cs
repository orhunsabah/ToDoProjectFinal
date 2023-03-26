using Dapper;
using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.UserData
{
    public interface IGetAllUsersDataRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    public class GetAllUsersDataRequest : IGetAllUsersDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetAllUsersDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            var query = $"SELECT * FROM [User]";
            var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetUserDataModel>(query);
            return response.ToList(); 

        }
    }
}
