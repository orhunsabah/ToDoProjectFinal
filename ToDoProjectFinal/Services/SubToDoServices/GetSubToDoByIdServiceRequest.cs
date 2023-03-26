using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IGetSubToDoByIdServiceRequest
    {
        Task<GetSubToDoDataModel> GetSubToDoById(int id);
    }
    public class GetSubToDoByIdServiceRequest : IGetSubToDoByIdServiceRequest
    {
        private readonly IGetSubToDoByIdDataRequest _getSubToDoByIdDataRequest;
        public GetSubToDoByIdServiceRequest (IGetSubToDoByIdDataRequest getSubToDoByIdDataRequest)
        {
            _getSubToDoByIdDataRequest= getSubToDoByIdDataRequest;
        }

        public async Task<GetSubToDoDataModel> GetSubToDoById(int id)
        {
            return await _getSubToDoByIdDataRequest.GetSubToDoById(id);
        }
    }
}
