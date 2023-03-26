using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.UserModels;

namespace ToDoProjectFinal.Data.UserData
{
    public interface IInsertUserDataRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserDataRequest : IInsertUserDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertUserDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            var query = "INSERT INTO [User](UserName,Password) VALUES(@UserName,@Password)";

            var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query, model);     

            return response > 0;

        }
    }
}
