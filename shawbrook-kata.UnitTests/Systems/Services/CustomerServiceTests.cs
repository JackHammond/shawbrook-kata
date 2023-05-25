using Moq;
using FluentAssertions;
using shawbrook_kata.Services;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Tests.Services
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetCustomer_ValidId_ReturnsCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerMock = new Mock<ICustomer?>();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.RetrieveCustomer(customerId)).Returns(Task.FromResult(customerMock.Object));

            var service = new CustomerService(customerRepositoryMock.Object);

            // Act
            var result = await service.GetCustomer(customerId);

            // Assert
            result.Should().Be(customerMock.Object);
        }

        [Fact]
        public async Task GetCustomer_InvalidId_ReturnsNull()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerMock = new Mock<ICustomer?>();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.RetrieveCustomer(customerId)).Returns(Task.FromResult((ICustomer?)null));

            var service = new CustomerService(customerRepositoryMock.Object);

            // Act
            var result = await service.GetCustomer(customerId);

            // Assert
            result.Should().Be(null);
        }

    }
}
