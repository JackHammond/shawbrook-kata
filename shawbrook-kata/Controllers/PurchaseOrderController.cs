using Microsoft.AspNetCore.Mvc;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;
using shawbrook_kata.Services;

namespace shawbrook_kata.Controllers
{
    [ApiController]
    [Route("api/v1/purchaseOrder/")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost("create", Name = "PostCreatePurchaseOrder")]
        public async Task<ActionResult<List<IPurchaseOrder>>> PostCreatePurchaseOrder([FromBody] List<Guid> itemIds)
        {
            // Make call to service using the itemIds
            // Process the purchase order creation based on the provided item IDs
            IPurchaseOrder? purchaseOrder = await _purchaseOrderService.ProcessPurchaseOrder(itemIds);

            if (purchaseOrder != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}