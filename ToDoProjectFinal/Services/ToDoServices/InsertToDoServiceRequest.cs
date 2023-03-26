using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Models.ToDoModels;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IInsertToDoServiceRequest
    {
        Task<bool> InsertToDo(InsertToDoDataModel model);
    }
    public class InsertToDoServiceRequest : IInsertToDoServiceRequest
    {
        private readonly IInsertToDoDataRequest _insertToDoDataRequest;
        public InsertToDoServiceRequest (IInsertToDoDataRequest insertToDoDataRequest)
        {
            _insertToDoDataRequest= insertToDoDataRequest;
        }

        public async Task<bool> InsertToDo(InsertToDoDataModel model)
        {
            return await _insertToDoDataRequest.InsertToDo(model);
        }
    }
}
