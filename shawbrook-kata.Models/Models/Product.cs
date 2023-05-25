using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Models
{
    public class Product : IProduct
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public bool PhysicalItem { get; set; }


    }
}
