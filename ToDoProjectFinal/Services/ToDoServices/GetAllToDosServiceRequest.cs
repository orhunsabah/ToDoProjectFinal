using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IGetAllToDosServiceRequest
    {
        Task<List<GetToDoDataModel>> GetAllToDos();
    }
    public class GetAllToDosServiceRequest : IGetAllToDosServiceRequest
    {
        private readonly IGetAllToDosDataRequest _getAllToDosDataRequest;
        public GetAllToDosServiceRequest (IGetAllToDosDataRequest getAllToDosDataRequest)
        {
            _getAllToDosDataRequest= getAllToDosDataRequest;
        }

        public async Task<List<GetToDoDataModel>> GetAllToDos()
        {
            return await _getAllToDosDataRequest.GetAllTodos();
        }
    }
}
