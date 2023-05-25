using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        List<IPurchaseOrder> purchaseOrderData = new List<IPurchaseOrder>();

        // This would contain a call to the database
        public Task CreatePurchaseOrder(IPurchaseOrder purchaseOrder)
        {
            purchaseOrderData.Add(purchaseOrder);
            return Task.CompletedTask;
        }
    }
}
