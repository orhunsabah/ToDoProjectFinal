using Microsoft.AspNetCore.Mvc;
using ToDoProjectFinal.Models.SubToDoModels;
using ToDoProjectFinal.Services.SubToDoServices;

namespace ToDoProjectFinal.Controllers
{
    [Route("[controller]")]
    public class SubToDoController : Controller
    {
        private readonly IGetAllSubToDosServiceRequest _getAllSubToDosServiceRequest;
        private readonly IGetSubToDoByIdServiceRequest _getSubToDoByIdServiceRequest;
        private readonly IDeleteSubToDoByIdServiceRequest _deleteSubToDoByIdServiceRequest;
        private readonly IInsertSubToDoServiceRequest _insertSubToDoServiceRequest;
        private readonly IGetSumOfDoneSubToDosByToDoIdServiceRequest _getSumOfDoneSubToDosByToDoIdServiceRequest;
        private readonly IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest;
        private readonly ISwitchSubToDoDoneServiceRequest _switchSubToDoDoneServiceRequest;

        public SubToDoController(IGetAllSubToDosServiceRequest getAllSubToDosServiceRequest, IGetSubToDoByIdServiceRequest getSubToDoByIdServiceRequest,
            IDeleteSubToDoByIdServiceRequest deleteSubToDoByIdServiceRequest, IInsertSubToDoServiceRequest insertSubToDoServiceRequest, IGetSumOfDoneSubToDosByToDoIdServiceRequest getSumOfDoneSubToDosByToDoIdServiceRequest
, IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest getEffectPercentageOfSubToDoBySubToDoIdServiceRequest , ISwitchSubToDoDoneServiceRequest switchSubToDoDoneServiceRequest)
        {
            _getAllSubToDosServiceRequest = getAllSubToDosServiceRequest;
            _getSubToDoByIdServiceRequest = getSubToDoByIdServiceRequest;
            _deleteSubToDoByIdServiceRequest = deleteSubToDoByIdServiceRequest;
            _insertSubToDoServiceRequest = insertSubToDoServiceRequest;
            _getSumOfDoneSubToDosByToDoIdServiceRequest = getSumOfDoneSubToDosByToDoIdServiceRequest;
            _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest = getEffectPercentageOfSubToDoBySubToDoIdServiceRequest;
            _switchSubToDoDoneServiceRequest= switchSubToDoDoneServiceRequest;
        }
        //EndPoints

        [HttpGet("subtodos")]
        public async Task<List<GetSubToDoDataModel>> GetAllSubToDos()
        {
            return await _getAllSubToDosServiceRequest.GetAllSubToDos();
        }
        [HttpGet("{id}")]
        public async Task<GetSubToDoDataModel> GetSubToDoById(int id)
        {
            return await _getSubToDoByIdServiceRequest.GetSubToDoById(id);
        }
        [HttpDelete("subtodos")]
        public async Task<bool> DeleteSubToDoById(int id)
        {
            return await _deleteSubToDoByIdServiceRequest.DeleteSubToDoById(id);
        }
        [HttpPost("insert")]
        public async Task<bool> InsertSubToDo([FromBody] InsertSubToDoDataModel model)
        {
            return await _insertSubToDoServiceRequest.InsertSubToDo(model);
        }
        [HttpGet("totalsubtodopercentage")]
        public async Task<int> GetSumOfDoneSubToDosByToDoId(int ToDoId)
        {
            return await _getSumOfDoneSubToDosByToDoIdServiceRequest.GetSumOfDoneSubToDosByToDoId(ToDoId);
        }
        [HttpGet("subtodopercbysubtodoid")] 
        public async Task<int> GetEffectPercentageOfSubToDo(int SubToDoId)
        {
            return await _getEffectPercentageOfSubToDoBySubToDoIdServiceRequest.GetEffectPercentageOfSubToDo(SubToDoId);
        }
        [HttpPut("switch-subtodo-done")]
        public async Task<bool> SwitchSubTodoDone(int SubTodoId)
        {
            return await _switchSubToDoDoneServiceRequest.SwitchSubToDoDone(SubTodoId);
        }
    }

    
}
