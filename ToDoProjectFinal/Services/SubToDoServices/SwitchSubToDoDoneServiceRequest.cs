using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Services.ToDoServices;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface ISwitchSubToDoDoneServiceRequest
    {
        Task<bool> SwitchSubToDoDone(int SubToDoId);
    }
    public class SwitchSubToDoDoneServiceRequest : ISwitchSubToDoDoneServiceRequest
    {
        private readonly ISwitchSubToDoDoneDataRequest _switchSubToDoDoneDataRequest;
        private readonly IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest;
        private readonly IGetToDoIdBySubToDoIdDataRequest _getToDoIdBySubToDoIdDataRequest;
        private readonly IGetProgressOfToDoByIdServiceRequest _getProgressOfToDoByIdServiceRequest;
        private readonly IChangeProgressOfToDoDataRequest _changeProgressOfToDoDataRequest;
        private readonly ISwitchToDoDoneDataRequest _switchToDoDoneDataRequest;

        public SwitchSubToDoDoneServiceRequest(ISwitchSubToDoDoneDataRequest switchSubToDoDoneDataRequest, IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest getEffectPercentageOfSubToDoBySubToDoIdServiceRequest, IGetToDoIdBySubToDoIdDataRequest getToDoIdBySubToDoIdDataRequest, IGetProgressOfToDoByIdServiceRequest getProgressOfToDoByIdServiceRequest, IChangeProgressOfToDoDataRequest changeProgressOfToDoDataRequest, ISwitchToDoDoneDataRequest switchToDoDoneDataRequest)
        {
            _switchSubToDoDoneDataRequest = switchSubToDoDoneDataRequest;
            _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest = getEffectPercentageOfSubToDoBySubToDoIdServiceRequest;
            _getToDoIdBySubToDoIdDataRequest = getToDoIdBySubToDoIdDataRequest;
            _getProgressOfToDoByIdServiceRequest = getProgressOfToDoByIdServiceRequest;
            _changeProgressOfToDoDataRequest = changeProgressOfToDoDataRequest;
            _switchToDoDoneDataRequest = switchToDoDoneDataRequest;
        }
        public async Task<bool> SwitchSubToDoDone(int SubToDoId)
        {
            var ToDoId = await _getToDoIdBySubToDoIdDataRequest.GetToDoIdBySubToDoId(SubToDoId);
            var EffectPercOfSubToDo = await _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest.GetEffectPercentageOfSubToDo(SubToDoId);
            var ToDoProgress = await _getProgressOfToDoByIdServiceRequest.GetProgressOfToDoById(ToDoId);
            var TotalProgressOfTodo = ToDoProgress + EffectPercOfSubToDo;
    
            if (TotalProgressOfTodo >= 100)
            {
                var IsProgressChange = await _changeProgressOfToDoDataRequest.ChangeProgressOfToDo(ToDoId, TotalProgressOfTodo);
                var IsToDoDone = await _switchToDoDoneDataRequest.SwitchToDoDone(ToDoId);
                var IsSubToDoDone = await _switchSubToDoDoneDataRequest.SwitchSubToDoDone(SubToDoId);

                if (IsProgressChange && IsSubToDoDone && IsToDoDone)
                {
                    return true;
                }
                    return false;
            }
            else
            {
                var IsProgressChange = await _changeProgressOfToDoDataRequest.ChangeProgressOfToDo(ToDoId, TotalProgressOfTodo);
                var IsSubToDoDone = await _switchSubToDoDoneDataRequest.SwitchSubToDoDone(SubToDoId);

                if (IsProgressChange && IsSubToDoDone)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
