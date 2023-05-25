using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Services
{
    public class ShippingService : IShippingService
    {
        public long GenerateShippingLabel(ICustomer customer)
        {
            // Generate label from address and name of customer
            // Email customer shipping 
            // Return tracking number
            return 123456;
        }
    }
}
