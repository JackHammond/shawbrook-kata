using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Models
{
    public class Customer : ICustomer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> CategoryAccess { get; set; }
        public List<IPurchaseOrder> PurchaseHistory { get; set; }
        public string Address { get; set; }
    }
}
