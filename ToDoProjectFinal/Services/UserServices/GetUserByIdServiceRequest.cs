using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.UserData;

namespace ToDoProjectFinal.Services.UserServices
{
    public interface IGetUserByIdServiceRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    public class GetUserByIdServiceRequest : IGetUserByIdServiceRequest
    {
        private readonly IGetUserByIdDataRequest _getUserByIdDataRequest;

        public GetUserByIdServiceRequest(IGetUserByIdDataRequest getUserByIdDataRequest)
        {
            _getUserByIdDataRequest = getUserByIdDataRequest;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdDataRequest.GetUserById(id);
        }
    }
}
