using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IUpdateToDoByIdServiceRequest
    {
        Task<bool> UpdateToDoById(InsertToDoDataModel model, int id);
    }
    public class UpdateToDoByIdServiceRequest : IUpdateToDoByIdServiceRequest
    {
        private readonly IUpdateToDoByIdDataRequest _updateToDoByIdDataRequest;
        public UpdateToDoByIdServiceRequest(IUpdateToDoByIdDataRequest updateToDoByIdDataRequest) 
        {
            _updateToDoByIdDataRequest = updateToDoByIdDataRequest;
        }

        public async Task<bool> UpdateToDoById(InsertToDoDataModel model, int id)
        {
            return await _updateToDoByIdDataRequest.UpdateToDoById(model, id);
        }
    }
}
