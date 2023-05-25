using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Models
{
    public class PurchaseOrder : IPurchaseOrder
    {
        public decimal Total { get; set; }
        public List<string> Items { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
