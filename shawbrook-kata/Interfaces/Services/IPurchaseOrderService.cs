using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface IPurchaseOrderService
    {
        public Task<IPurchaseOrder?> ProcessPurchaseOrder(List<Guid> purchaseItems);
    }
}
