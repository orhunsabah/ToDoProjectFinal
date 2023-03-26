using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Models.SubToDoModels;
using ToDoProjectFinal.Models.UserModels;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IInsertSubToDoServiceRequest
    {
        Task<bool> InsertSubToDo(InsertSubToDoDataModel model);
    }
    public class InsertSubToDoServiceRequest : IInsertSubToDoServiceRequest
    {
        private readonly IInsertSubToDoDataRequest _insertSubToDoDataRequest;
        public InsertSubToDoServiceRequest(IInsertSubToDoDataRequest insertSubToDoDataRequest)
        {
            _insertSubToDoDataRequest = insertSubToDoDataRequest;
        }
        public async Task<bool> InsertSubToDo(InsertSubToDoDataModel model)
        {
            return await _insertSubToDoDataRequest.InsertSubToDo(model);
        }
    }
}
