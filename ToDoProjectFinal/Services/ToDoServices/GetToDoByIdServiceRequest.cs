using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IGetToDoByIdServiceRequest
    {
        Task<GetToDoDataModel> GetToDoById(int id);
    }
    public class GetToDoByIdServiceRequest : IGetToDoByIdServiceRequest
    {
        private readonly IGetToDoByIdDataRequest _getToDoByIdDataRequest;
        public GetToDoByIdServiceRequest (IGetToDoByIdDataRequest getToDoByIdDataRequest)
        {
            _getToDoByIdDataRequest = getToDoByIdDataRequest;
        }

        public async Task<GetToDoDataModel> GetToDoById(int id)
        {
            return await _getToDoByIdDataRequest.GetToDoById(id);
        }
    }
}
