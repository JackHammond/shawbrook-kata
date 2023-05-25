using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<List<IProduct>> GetProducts()
        {
            return _productRepository.RetrieveAllProducts();
        }

    }
}
