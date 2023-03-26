using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.UserData
{
    public interface IDeleteUserByIdDataRequest
    {
        Task<bool> DeleteUserById(int id);
    }
    public class DeleteUserByIdDataRequest : IDeleteUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public DeleteUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> DeleteUserById(int id)
        {
            var query = $"DELETE FROM [User] WHERE Id = {id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
