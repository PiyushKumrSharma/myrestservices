using Microsoft.AspNetCore.Mvc;
using Moq;
using myrestservices.Controller;
using myrestservices.Models;
using myrestservices.Services;

namespace myrestservicestest
{
    public class UserCheckTest
    {
        [Fact]
        public async Task ChecKUserCheckControllerTestAsync()
        {
            // Arrange
            var expectedUser = new User
            {
                Name = new Name
                {
                    First = "John",
                    Last = "Doe"
                },
                Email = "john.doe@example.com",
                Gender = "M"
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetRandomUserAsync()).ReturnsAsync(expectedUser);

            var controller = new UserController(userServiceMock.Object);

            // Act
            var result = await controller.GetRandomUser();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUser = Assert.IsAssignableFrom<User>(okResult.Value);
            Assert.Equal(expectedUser.Name, actualUser.Name);
            Assert.Equal(expectedUser.Email, actualUser.Email);
            Assert.Equal(expectedUser.Gender, actualUser.Gender);
        }
    }
}