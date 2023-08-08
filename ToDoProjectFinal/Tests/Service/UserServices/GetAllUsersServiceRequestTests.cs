using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProjectFinal.Data.UserData;
using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Services.UserServices;

namespace ToDoProjectFinal.Tests.Services.UserServices
{
    [TestFixture]
    public class GetAllUsersServiceRequestTests
    {
        [Test]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<GetUserDataModel>
            {
                new GetUserDataModel {Id = 1, UserName = "Orhun", Password = "or123hun" },
                new GetUserDataModel {Id = 2, UserName = "Tugberk", Password = "tug33berk"}
            };

            var getAllUsersDataRequestMock = new Mock<IGetAllUsersDataRequest>();
            getAllUsersDataRequestMock.Setup(r => r.GetAllUsers()).ReturnsAsync(expectedUsers);

            var getAllUsersServiceRequest = new GetAllUsersServiceRequest(getAllUsersDataRequestMock.Object);

            // Act
            var result = await getAllUsersServiceRequest.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUsers.Count, result.Count);
            // Add additional assertions if necessary

            getAllUsersDataRequestMock.Verify(r => r.GetAllUsers(), Times.Once);
        }
    }
}
