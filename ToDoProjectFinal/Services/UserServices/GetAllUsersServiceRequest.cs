using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.UserData;

namespace ToDoProjectFinal.Services.UserServices
{
    public interface IGetAllUsersServiceRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    public class GetAllUsersServiceRequest:IGetAllUsersServiceRequest
    {
        private readonly IGetAllUsersDataRequest _getAllUsersDataRequest;

        public GetAllUsersServiceRequest (IGetAllUsersDataRequest getAllUsersDataRequest)
        {
            _getAllUsersDataRequest = getAllUsersDataRequest;
        }
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersDataRequest.GetAllUsers();
        }
    }
}
