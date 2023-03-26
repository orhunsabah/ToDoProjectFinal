using ToDoProjectFinal.Data.SubToDoData;

namespace ToDoProjectFinal.Services.SubToDoServices
{
    public interface IDeleteSubToDoByIdServiceRequest
    {
        Task<bool> DeleteSubToDoById(int id);
    }
    public class DeleteSubToDoByIdServiceRequest : IDeleteSubToDoByIdServiceRequest
    {
        private readonly IDeleteSubToDoByIdDataRequest _deleteSubToDoByIdDataRequest;
        public DeleteSubToDoByIdServiceRequest (IDeleteSubToDoByIdDataRequest deleteSubToDoByIdDataRequest)
        {
            _deleteSubToDoByIdDataRequest= deleteSubToDoByIdDataRequest;
        }

        public async Task<bool> DeleteSubToDoById(int id)
        {
            return await _deleteSubToDoByIdDataRequest.DeleteSubToDoById(id);
        }
    }
}
