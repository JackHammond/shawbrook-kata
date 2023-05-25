namespace shawbrook_kata.Models.Interfaces
{
    public interface IProduct
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public bool PhysicalItem { get; set; }
    }
}
