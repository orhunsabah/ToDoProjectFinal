using ToDoProjectFinal.Data.SubToDoData;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IGetSumOfDoneSubToDosByToDoIdServiceRequest
    {
        Task<int> GetSumOfDoneSubToDosByToDoId(int ToDoId);
    }
    public class GetSumOfDoneSubToDosByToDoIdServiceRequest : IGetSumOfDoneSubToDosByToDoIdServiceRequest
    {
        private readonly IGetSumOfDoneSubToDosByToDoIdDataRequest _getSumOfDoneSubToDosByToDoIdDataRequest;
        public GetSumOfDoneSubToDosByToDoIdServiceRequest (IGetSumOfDoneSubToDosByToDoIdDataRequest getSumOfDoneSubToDosByToDoIdDataRequest)
        {
            _getSumOfDoneSubToDosByToDoIdDataRequest = getSumOfDoneSubToDosByToDoIdDataRequest;
        }

        public async Task<int> GetSumOfDoneSubToDosByToDoId(int ToDoId)
        {
            return await _getSumOfDoneSubToDosByToDoIdDataRequest.GetSumOfDoneSubToDosByToDoId(ToDoId);
        }
            
    }
}
