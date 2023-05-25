namespace shawbrook_kata.Models.Interfaces
{
    public interface ICustomer
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        public string Password { get; set; }
        List<string> CategoryAccess { get; set; }
        List<IPurchaseOrder> PurchaseHistory { get; set; }
        public string Address { get; set; }
    }
}
