using NUnit.Framework;
using ToDoProjectFinal.Models.UserModels;
using ToDoProjectFinal.Services.UserServices;

namespace ToDoProjectFinal.Tests.Data.UserData
{
    [TestFixture]
    public class GetUserByIdDataRequestIntegrationTests
    {
        private readonly IGetUserByIdServiceRequest _getUserByIdServiceRequest;
        private readonly IInsertUserServiceRequest _insertUserServiceRequest;


        public GetUserByIdDataRequestIntegrationTests(IGetUserByIdServiceRequest getUserByIdServiceRequest, IInsertUserServiceRequest insertUserServiceRequest)
        {
            _getUserByIdServiceRequest = getUserByIdServiceRequest;
            _insertUserServiceRequest = insertUserServiceRequest;
        }

        [Test]
        public async Task GetUserById_ShouldReturnUser()
        {

            InsertUserDataModel user = new InsertUserDataModel
            {
                Id = 50,
                UserName = "orhuntest",
                Password = "testsifre123"
            };

            var isInserted = await _insertUserServiceRequest.InsertUser(user);

            if (isInserted)
            {
                var result = await _getUserByIdServiceRequest.GetUserById(user.Id);
                Assert.AreEqual(user, result);
            }
        }
    }
}