using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface IProductService
    {
        public Task<List<IProduct>> GetProducts();
    }
}
