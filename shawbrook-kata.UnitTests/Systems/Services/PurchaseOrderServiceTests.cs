using Moq;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;
using shawbrook_kata.Services;

namespace shawbrook_kata.Tests.Services
{
    public class PurchaseOrderServiceTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly Mock<IPurchaseOrderRepository> _purchaseOrderRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IShippingService> _shippingServiceMock;
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchaseOrderServiceTests()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _purchaseOrderRepositoryMock = new Mock<IPurchaseOrderRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _shippingServiceMock = new Mock<IShippingService>();

            _purchaseOrderService = new PurchaseOrderService(
                _customerServiceMock.Object,
                _purchaseOrderRepositoryMock.Object,
                _productRepositoryMock.Object,
                _shippingServiceMock.Object
            );
        }

        [Fact]
        public async Task ProcessPurchaseOrder_ValidPurchaseItems_ReturnsPurchaseOrder()
        {
            // Arrange
            var purchaseItems = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            var customerServiceMock = new Mock<ICustomerService>();
            var purchaseOrderRepositoryMock = new Mock<IPurchaseOrderRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var shippingServiceMock = new Mock<IShippingService>();

            var customerId = Guid.NewGuid();
            var customerMock = new Mock<ICustomer>();
            customerMock.Setup(c => c.Id).Returns(customerId);
            customerMock.Setup(c => c.CategoryAccess).Returns(new List<string>());
            customerMock.Setup(c => c.PurchaseHistory).Returns(new List<IPurchaseOrder>());

            var expectedProducts = new List<IProduct>
            {
                new Product()
                {
                    Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e5"),
                    Title = "Membership Item",
                    Price = 9.99m,
                    PhysicalItem = false,
                    Type = "Membership"
                },
                new Product()
                {
                    Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e4"),
                    Title = "Movie Item",
                    Price = 9.99m,
                    PhysicalItem = false,
                    Type = "Books"
                },
            };

            customerServiceMock.Setup(cs => cs.GetCustomerId()).Returns(customerId);
            customerServiceMock.Setup(cs => cs.GetCustomer(It.IsAny<Guid>())).ReturnsAsync(customerMock.Object);
            productRepositoryMock.Setup(pr => pr.RetrieveProducts(purchaseItems)).Returns(expectedProducts);
            shippingServiceMock.Setup(ss => ss.GenerateShippingLabel(customerMock.Object)).Returns(123456);

            var purchaseOrderService = new PurchaseOrderService(
                customerServiceMock.Object,
                purchaseOrderRepositoryMock.Object,
                productRepositoryMock.Object,
                shippingServiceMock.Object);

            // Act
            var result = await purchaseOrderService.ProcessPurchaseOrder(purchaseItems);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.CustomerId);
            Assert.NotEqual(Guid.Empty, result.PurchaseOrderId);
        }

    }
}
