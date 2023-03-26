using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IGetAllSubToDosServiceRequest
    {
        Task<List<GetSubToDoDataModel>> GetAllSubToDos();
    }
    public class GetAllSubToDosServiceRequest : IGetAllSubToDosServiceRequest
    {
        private readonly IGetAllSubToDosDataRequest _getAllSubToDosDataRequest;
        public GetAllSubToDosServiceRequest (IGetAllSubToDosDataRequest getAllSubToDosDataRequest)
        {
            _getAllSubToDosDataRequest= getAllSubToDosDataRequest;
        }

        public async Task<List<GetSubToDoDataModel>> GetAllSubToDos()
        {
            return await _getAllSubToDosDataRequest.GetAllSubTodos();
        }
    }
}
