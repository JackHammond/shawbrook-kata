using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface IPurchaseOrderRepository
    {
        public Task CreatePurchaseOrder(IPurchaseOrder purchaseOrder);
    }
}
