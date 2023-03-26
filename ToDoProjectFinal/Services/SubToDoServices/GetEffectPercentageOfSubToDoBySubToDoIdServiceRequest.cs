using ToDoProjectFinal.Data.SubToDoData;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest
    {
        Task<int> GetEffectPercentageOfSubToDo(int subToDoId);
    }
    public class GetEffectPercentageOfSubToDoBySubToDoIdServiceRequest : IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest
    {
        private readonly IGetEffectPercentageOfSubToDoBySubToDoIdDataRequest _getEffectPercentageOfSubToDoByToDoIdDataRequest;
        public GetEffectPercentageOfSubToDoBySubToDoIdServiceRequest(IGetEffectPercentageOfSubToDoBySubToDoIdDataRequest getEffectPercentageOfSubToDoBySubToDoIdDataRequest)
        {
            _getEffectPercentageOfSubToDoByToDoIdDataRequest = getEffectPercentageOfSubToDoBySubToDoIdDataRequest;
        }

        public async Task<int> GetEffectPercentageOfSubToDo(int SubToDoId)
        {
            return await _getEffectPercentageOfSubToDoByToDoIdDataRequest.GetEffectPercentageOfSubToDo(SubToDoId);
        }
    }
}
