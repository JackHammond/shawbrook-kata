using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        ICustomer? customerData = new Customer()
        {
            Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e5"),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "********",
            CategoryAccess = new List<string> { "Movies" },
            PurchaseHistory = new List<IPurchaseOrder>()
        };
        public Task<ICustomer?> RetrieveCustomer(Guid id)
        {
            try
            {
                // I would make a call to a database here.
                return Task.FromResult(customerData);
            }
            catch (Exception)
            {
                // Log exception
                customerData = null;
                return Task.FromResult(customerData);
            }
        }

        public void UpdateCustomer(ICustomer customer)
        {
            // I would make a call to a database here.
            customerData = customer;
        }
    }
}
