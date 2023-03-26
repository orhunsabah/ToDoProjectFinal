using System.Reflection.Metadata.Ecma335;
using Dapper;
using ToDoProjectFinal.Data.Utils;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface ISwitchSubToDoDoneDataRequest
    {
        Task<bool> SwitchSubToDoDone(int id);
    }
    public class SwitchSubToDoDoneDataRequest : ISwitchSubToDoDoneDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public SwitchSubToDoDoneDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> SwitchSubToDoDone(int id)
        {
            var query = $"UPDATE SubToDo SET IsDone = 1 WHERE Id={id}";
            var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0 ;
        }
    }
}
