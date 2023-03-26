using Dapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Data.ToDoData
{
    public interface IGetAllToDosDataRequest
    {
        Task<List<GetToDoDataModel>> GetAllTodos();
    }
    public class GetAllToDosDataRequest : IGetAllToDosDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetAllToDosDataRequest (IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetToDoDataModel>> GetAllTodos()
        {
            var query = $"SELECT * FROM ToDo";
            var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetToDoDataModel> (query);
            return response.ToList();
        }
    }
}
