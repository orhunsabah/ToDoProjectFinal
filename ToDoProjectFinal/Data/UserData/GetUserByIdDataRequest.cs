using Dapper;
using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.UserData
{
    public interface IGetUserByIdDataRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    public class GetUserByIdDataRequest : IGetUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            var query = $"SELECT * FROM [User] WHERE Id = {id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetUserDataModel>(query);
            return response;

        }
        
    }
}
