using NUnit.Framework;
using Moq;
using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Models.UserModels;
using ToDoProjectFinal.Services.UserServices;

namespace ToDoProjectFinal.Tests.Services.UserServices
{
    [TestFixture]
    public class InsertUserServiceRequestTests
    {
        [Test]
        public async Task InsertUser_ValidModel_ReturnsTrue()
        {
            // Arrange
            var model = new InsertUserDataModel {UserName = "Orhun", Password = "123or123"};

            var insertUserDataRequestMock = new Mock<IInsertUserDataRequest>();
            insertUserDataRequestMock.Setup(r => r.InsertUser(model)).ReturnsAsync(true);

            var userServiceRequest = new InsertUserServiceRequest(insertUserDataRequestMock.Object);

            // Act
            var result = await userServiceRequest.InsertUser(model);

            // Assert
            Assert.IsTrue(result);
            insertUserDataRequestMock.Verify(r => r.InsertUser(model), Times.Once);
        }
    }
}
