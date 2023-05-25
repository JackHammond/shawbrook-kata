using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces.Services
{
    public interface IProductRepository
    {
        public List<IProduct> RetrieveProducts(List<Guid> ids);
        public Task<List<IProduct>> RetrieveAllProducts();
        public void UpdateProduct(IProduct Product);

    }
}
