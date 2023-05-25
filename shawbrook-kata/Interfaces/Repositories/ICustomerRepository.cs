using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface ICustomerRepository
    {
        public Task<ICustomer?> RetrieveCustomer(Guid id);
        public void UpdateCustomer(ICustomer customer);
    }
}
