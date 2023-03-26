using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Models.SubToDoModels;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IGetCountOfSubToDosByToDoIdServiceRequest
    {
        Task<int> GetCountOfSubToDosByToDoId(int ToDoId);
    }
    public class GetCountOfSubToDosByToDoIdServiceRequest : IGetCountOfSubToDosByToDoIdServiceRequest
    {
        private readonly IGetCountOfSubToDosByToDoIdDataRequest _getCountOfSubToDosByToDoIdDataRequest;
        public GetCountOfSubToDosByToDoIdServiceRequest(IGetCountOfSubToDosByToDoIdDataRequest getCountOfSubToDosByToDoIdDataRequest)
        {
            _getCountOfSubToDosByToDoIdDataRequest = getCountOfSubToDosByToDoIdDataRequest;
        }

        public async Task<int> GetCountOfSubToDosByToDoId(int ToDoId)
        {
            return await _getCountOfSubToDosByToDoIdDataRequest.GetCountOfSubToDosByToDoId(ToDoId);
        }
    }
}
