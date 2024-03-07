using Microsoft.AspNetCore.Mvc;
using myrestservices.Controller;

namespace myrestservicestest
{
    public class HealthCheckTest
    {
        [Fact]
        public void ChecKHealthCheckControllerTest()
        {
            // Arrange
            var controller = new HealthCheckController();

            // Act
            var result = controller.CheckHealth();

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}