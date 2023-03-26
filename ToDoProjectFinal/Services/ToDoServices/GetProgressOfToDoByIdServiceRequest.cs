using ToDoProjectFinal.Data.ToDoData;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IGetProgressOfToDoByIdServiceRequest
    {
         Task<int> GetProgressOfToDoById(int Id);
    }
    public class GetProgressOfToDoByIdServiceRequest:IGetProgressOfToDoByIdServiceRequest
    {
        private readonly IGetProgressOfToDoByIdDataRequest _getProgressOfToDoByIdDataRequest;
        public GetProgressOfToDoByIdServiceRequest(IGetProgressOfToDoByIdDataRequest getProgressOfToDoByIdDataRequest)
        {
            _getProgressOfToDoByIdDataRequest = getProgressOfToDoByIdDataRequest;
        }

        public async Task<int> GetProgressOfToDoById(int Id)
        {
            return await _getProgressOfToDoByIdDataRequest.GetProgressOfToDoById(Id);
        }
    }
}
