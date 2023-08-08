using Moq;
using NUnit.Framework;
using TodoProject1.Model.UserModels;
using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Services.UserServices;

namespace FinalTodoProject.Api.Tests.Service.UserServices
{
    [TestFixture]
    public class GetUserByIdServieRequestTests
    {
        [Test]
        public async Task GetUserById_ShouldReturnUser()
        {

            // Arrange
            int userId = 1;
            GetUserDataModel expectedUser = new GetUserDataModel { Id = userId, UserName = "Orhun", Password = "or123hun" };

            var mockGetUserByIdDataRequest = new Mock<IGetUserByIdDataRequest>();
            mockGetUserByIdDataRequest.Setup(d => d.GetUserById(userId)).ReturnsAsync(expectedUser);

            var getUserByIdServiceRequest = new GetUserByIdServiceRequest(mockGetUserByIdDataRequest.Object);

            // Act
            GetUserDataModel result = await getUserByIdServiceRequest.GetUserById(userId);

            // Assert
            Assert.AreEqual(expectedUser, result);
        }
    }
}
