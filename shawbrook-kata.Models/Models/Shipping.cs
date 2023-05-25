using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Models
{
    public class Shipping : IShipping
    {
        public long TrackingNumber { get; set; }
        public List<IProduct> PhysicalProducts { get; set; }
    }
}
