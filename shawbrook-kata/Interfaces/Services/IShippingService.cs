using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface IShippingService
    {
        public long GenerateShippingLabel(ICustomer customer);
    }
}
