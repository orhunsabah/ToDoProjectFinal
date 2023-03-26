using Microsoft.AspNetCore.Mvc;
using ToDoProjectFinal.Models.ToDoModels;
using ToDoProjectFinal.Services.ToDoServices;

namespace ToDoProjectFinal.Controllers
{
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly IGetAllToDosServiceRequest _getAllTodosServiceRequest;
        private readonly IGetToDoByIdServiceRequest _getToDoByIdServiceRequest; 
        private readonly IDeleteToDoByIdServiceRequest _deleteToDoByIdServiceRequest;
        private readonly IInsertToDoServiceRequest _insertToDoServiceRequest;
        private readonly IUpdateToDoByIdServiceRequest _updateToDoByIdServiceRequest;

        public ToDoController(IGetAllToDosServiceRequest getAllToDosServiceRequest, IGetToDoByIdServiceRequest getToDoByIdServiceRequest,
            IDeleteToDoByIdServiceRequest deleteToDoByIdServiceRequest, IInsertToDoServiceRequest insertToDoServiceRequest, IUpdateToDoByIdServiceRequest updateToDoByIdServiceRequest)
        {
            _getAllTodosServiceRequest = getAllToDosServiceRequest;
            _getToDoByIdServiceRequest = getToDoByIdServiceRequest;
            _deleteToDoByIdServiceRequest = deleteToDoByIdServiceRequest;
            _insertToDoServiceRequest = insertToDoServiceRequest;
            _updateToDoByIdServiceRequest = updateToDoByIdServiceRequest;
         
        }
        //Endpoints

        [HttpGet("todos")]
        public async Task<List<GetToDoDataModel>> GetAllTodos()
        {
            return await _getAllTodosServiceRequest.GetAllToDos();
        }
        [HttpGet("{id}")]
        public async Task<GetToDoDataModel> GetTodoById(int id)
        {
            return await _getToDoByIdServiceRequest.GetToDoById(id);
        }
        [HttpDelete("Todos")]
        public async Task<bool> DeleteToDoById(int id)
        {
            return await _deleteToDoByIdServiceRequest.DeleteToDoById(id);
        }
        [HttpPost("insert")]
        public async Task<bool> InsertToDo([FromBody] InsertToDoDataModel model)
        {
            return await _insertToDoServiceRequest.InsertToDo(model);
        }
        [HttpPut("update/{id}")]
        public async Task<bool> UpdateToDoById([FromBody] InsertToDoDataModel model, int id)
        {
            return await _updateToDoByIdServiceRequest.UpdateToDoById(model, id);
        }
    }
}