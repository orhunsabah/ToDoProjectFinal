using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Models.UserModels;

namespace ToDoProjectFinal.Services.UserServices
{
    public interface IUpdateUserByIdServiceRequest
    {
        Task<bool> UpdateUserById(InsertUserDataModel model, int id);
    }
    public class UpdateUserByIdServiceRequest:IUpdateUserByIdServiceRequest
    {
        private readonly IUpdateUserByIdDataRequest _updateUserByIdDataRequest;
        public UpdateUserByIdServiceRequest(IUpdateUserByIdDataRequest updateUserByIdDataRequest)
        {
            _updateUserByIdDataRequest= updateUserByIdDataRequest; 
        }

        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id)
        {
            return await _updateUserByIdDataRequest.UpdateUserById(model, id);
        }
    }
}
