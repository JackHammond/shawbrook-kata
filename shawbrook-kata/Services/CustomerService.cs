using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<ICustomer?> GetCustomer(Guid id)
        {
            return _customerRepository.RetrieveCustomer(id);
        }

        public Guid GetCustomerId()
        {
            // This would use the JWT token to access the user id on the auth header of the request
            return new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e5");
        }

        public Task UpdateCustomer(ICustomer customer)
        {
            _customerRepository.UpdateCustomer(customer);
            return Task.CompletedTask;
        }
    }
}
