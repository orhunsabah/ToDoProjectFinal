using Dapper;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Data.SubToDoData
{
    public interface IGetAllSubToDosDataRequest
    {
        Task<List<GetSubToDoDataModel>> GetAllSubTodos();
    }
    public class GetAllSubToDosDataRequest : IGetAllSubToDosDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;
        public GetAllSubToDosDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetSubToDoDataModel>> GetAllSubTodos()
        {
            var query = $"SELECT * FROM SubToDo";
            var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetSubToDoDataModel>(query) ;
            return response.ToList() ;
        }
    }
}
