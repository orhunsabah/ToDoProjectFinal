using System.Threading.Tasks;
using ToDoProjectFinal.Data.SubToDoData;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IDeleteAllSubToDosByToDoIdServiceRequest
    {
        Task<bool> DeleteAllSubToDosByToDoId(int ToDoId);
    }
    public class DeleteAllSubToDosByToDoIdServiceRequest : IDeleteAllSubToDosByToDoIdServiceRequest
    {
        private readonly IDeleteAllSubToDosByToDoIdDataRequest _deleteAllSubToDosByToDoIdDataRequest;
        public DeleteAllSubToDosByToDoIdServiceRequest(IDeleteAllSubToDosByToDoIdDataRequest deleteAllSubToDosByToDoIdDataRequest)
        {
            _deleteAllSubToDosByToDoIdDataRequest = deleteAllSubToDosByToDoIdDataRequest;
        }
        public async Task<bool> DeleteAllSubToDosByToDoId(int ToDoId)
        {
            return await _deleteAllSubToDosByToDoIdDataRequest.DeleteAllSubToDosByToDoId(ToDoId);
        }
    }
}
