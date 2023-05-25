using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using shawbrook_kata.Controllers;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Tests.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task GetCustomer_ValidId_ReturnsCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerMock = new Mock<ICustomer>();

            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetCustomer(customerId)).ReturnsAsync(customerMock.Object);

            var controller = new CustomerController(customerServiceMock.Object);

            // Act
            var sut = await controller.GetCustomer(customerId);

            // Assert
            sut.Result.Should().BeOfType<OkObjectResult>();
            var actualResult = sut.Result as OkObjectResult;
            actualResult!.Value.Should().Be(customerMock.Object);
        }

        [Fact]
        public async Task GetCustomer_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var customerId = Guid.NewGuid();

            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetCustomer(customerId)).ReturnsAsync((ICustomer?)null);

            var controller = new CustomerController(customerServiceMock.Object);

            // Act
            var sut = await controller.GetCustomer(customerId);

            // Assert
            sut.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
