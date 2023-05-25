namespace shawbrook_kata.Models.Interfaces
{
    public interface IPurchaseOrder
    {
        decimal Total { get; set; }
        List<string> Items { get; set; }
        Guid PurchaseOrderId { get; set; }
        Guid CustomerId { get; set; }
    }
}
