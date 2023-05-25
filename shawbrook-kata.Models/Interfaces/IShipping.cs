namespace shawbrook_kata.Models.Interfaces
{
    public interface IShipping
    {
        public long TrackingNumber { get; set; }
        public List<IProduct> PhysicalProducts { get; set; }
    }
}
