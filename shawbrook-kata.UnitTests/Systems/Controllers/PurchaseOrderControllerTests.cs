using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shawbrook_kata.Controllers;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Tests.Controllers
{
    public class PurchaseOrderControllerTests
    {
        private readonly Mock<IPurchaseOrderService> _purchaseOrderServiceMock;
        private readonly PurchaseOrderController _controller;

        public PurchaseOrderControllerTests()
        {
            _purchaseOrderServiceMock = new Mock<IPurchaseOrderService>();
            _controller = new PurchaseOrderController(_purchaseOrderServiceMock.Object);
        }

    }
}
