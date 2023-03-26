using Microsoft.AspNetCore.Mvc;
using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Models.UserModels;
using ToDoProjectFinal.Services.UserServices;

namespace ToDoProjectFinal.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IGetAllUsersServiceRequest _getAllUsersServiceRequest;
        private readonly IGetUserByIdServiceRequest _getUserByIdServiceRequest;
        private readonly IDeleteUserByIdServiceRequest _deleteUserByIdServiceRequest;
        private readonly IInsertUserServiceRequest _insertUserServiceRequest;
        private readonly IUpdateUserByIdServiceRequest _updateUserByIdServiceRequest;
        public UserController(IGetAllUsersServiceRequest getAllUsersServiceRequest, IGetUserByIdServiceRequest getUserByIdServiceRequest, IDeleteUserByIdServiceRequest deleteUserByIdServiceRequest,
            IInsertUserServiceRequest insertUserServiceRequest, IUpdateUserByIdServiceRequest updateUserByIdServiceRequest)
        {
            _getAllUsersServiceRequest = getAllUsersServiceRequest;
            _getUserByIdServiceRequest = getUserByIdServiceRequest;
            _deleteUserByIdServiceRequest = deleteUserByIdServiceRequest;
            _insertUserServiceRequest = insertUserServiceRequest;
            _updateUserByIdServiceRequest = updateUserByIdServiceRequest;
        }

        //Endpoints

        [HttpGet("users")]
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersServiceRequest.GetAllUsers();
        }
        [HttpGet("{id}")]
        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdServiceRequest.GetUserById(id);
        }
        [HttpDelete("users")]
        public async Task<bool> DeleteUserById(int id)
        {
            return await _deleteUserByIdServiceRequest.DeleteUserById(id);
        }
        [HttpPost("insert")]
        public async Task<bool> InsertUser([FromBody]InsertUserDataModel model)
        {
            return await _insertUserServiceRequest.InsertUser(model);
        }
        [HttpPut("update/{id}")]
        public async Task<bool> UpdateUserById([FromBody] InsertUserDataModel model, int id)
        {
            return await _updateUserByIdServiceRequest.UpdateUserById(model, id);
        }
    }

    

}
