using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface ISwitchToDoDoneDataRequest
    {
        Task<bool> SwitchToDoDone(int id);
    }
    public class SwitchToDoDoneDataRequest : ISwitchToDoDoneDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public SwitchToDoDoneDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchToDoDone(int id)
        {
            var query = $"UPDATE ToDo SET IsDone = 1 WHERE Id = {id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query) ;
            return response > 0 ;
        }
    }
}
