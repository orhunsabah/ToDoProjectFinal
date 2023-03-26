using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Services.SubToDoServices;

namespace ToDoProjectFinal.Services.ToDoServices
{
    public interface IDeleteToDoByIdServiceRequest
    {
        Task<bool> DeleteToDoById(int id);
    }
    public class DeleteToDoByIdServiceRequest : IDeleteToDoByIdServiceRequest
    {
        private readonly IDeleteToDoByIdDataRequest _deleteToDoByIdDataRequest;
        private readonly IDeleteAllSubToDosByToDoIdServiceRequest _deleteAllSubToDosByToDoIdServiceRequest;
        private readonly IGetCountOfSubToDosByToDoIdServiceRequest _getCountOfSubToDosByToDoIdServiceRequest;
        public DeleteToDoByIdServiceRequest(IDeleteToDoByIdDataRequest deleteToDoByIdDataRequest, IDeleteAllSubToDosByToDoIdServiceRequest deleteAllSubToDosByToDoIdServiceRequest,
            IGetCountOfSubToDosByToDoIdServiceRequest getCountOfSubToDosByToDoIdServiceRequest)
        {
            _deleteToDoByIdDataRequest = deleteToDoByIdDataRequest;
            _deleteAllSubToDosByToDoIdServiceRequest = deleteAllSubToDosByToDoIdServiceRequest;
            _getCountOfSubToDosByToDoIdServiceRequest = getCountOfSubToDosByToDoIdServiceRequest;
        }

        public async Task<bool> DeleteToDoById(int id)
        {
            var getsubtodonumber = await _getCountOfSubToDosByToDoIdServiceRequest.GetCountOfSubToDosByToDoId(id);
            if (getsubtodonumber > 0)
            {
                var isdeleted = await _deleteAllSubToDosByToDoIdServiceRequest.DeleteAllSubToDosByToDoId(id);  //ToDo:Rename the variable
                if (isdeleted == true)
                {
                    return await _deleteToDoByIdDataRequest.DeleteToDoById(id);
                }
                return false;
            }
            else
            {
                return await _deleteToDoByIdDataRequest.DeleteToDoById(id);
            }

      
        }
    }
}
