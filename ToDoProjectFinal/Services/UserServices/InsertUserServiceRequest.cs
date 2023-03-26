using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Models.UserModels;

namespace ToDoProjectFinal.Services.UserServices
{
    public interface IInsertUserServiceRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserServiceRequest : IInsertUserServiceRequest
    {
        private readonly IInsertUserDataRequest _insertUserDataRequest;

        public InsertUserServiceRequest (IInsertUserDataRequest insertUserDataRequest)
        {
            _insertUserDataRequest = insertUserDataRequest;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            return await _insertUserDataRequest.InsertUser(model);
        }
    }
}
