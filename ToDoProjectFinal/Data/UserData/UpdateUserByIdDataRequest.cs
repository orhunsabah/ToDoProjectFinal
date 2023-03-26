using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.UserModels;

namespace ToDoProjectFinal.Data.UserData
{
    public interface IUpdateUserByIdDataRequest
    {
        Task<bool> UpdateUserById(InsertUserDataModel model, int id);
    }
    public class UpdateUserByIdDataRequest : IUpdateUserByIdDataRequest 
    {
        private readonly IProjectDbConnection _dbConnnection;
        public UpdateUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnnection = dbConnection;
        }
        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id)
        {
            var query = $"UPDATE [User] SET UserName = @UserName, Password = @Password WHERE Id = {id}";
            var conn = _dbConnnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}
