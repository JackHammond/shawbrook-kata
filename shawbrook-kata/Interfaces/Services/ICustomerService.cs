using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<ICustomer?> GetCustomer(Guid id);
        public Task UpdateCustomer(ICustomer customer);
        public Guid GetCustomerId();
    }
}
