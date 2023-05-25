using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;
using System;

namespace shawbrook_kata.Repository
{
    public class ProductRepository : IProductRepository
    {
        List<IProduct> products = new List<IProduct>()
        {
            new Product()
        {
            Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e5"),
            Title = "Membership Item",
            Price = 9.99m,
            PhysicalItem = false,
            Type = "Membership"
        },
            new Product()
        {
            Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e4"),
            Title = "Movie Item",
            Price = 9.99m,
            PhysicalItem = false,
            Type = "Books"

            },
            new Product()
        {
            Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e3"),
            Title = "Book Item",
            Price = 9.99m,
            PhysicalItem = true,
            Type = "Books"
        }
        };

        public Task<List<IProduct>> RetrieveAllProducts()
        {
            // This would return all products for now and could be separated into seperate objects later.
            try
            {
                // I would make a call to a database here.
                return Task.FromResult(products);
            }
            catch (Exception)
            {
                // Log exception
                List<IProduct> emptyList = new List<IProduct>();
                return Task.FromResult(emptyList);
            }
        }

        public List<IProduct> RetrieveProducts(List<Guid> ids)
        {
            // I would make a call to a database here based on the ids passed in.
            // Matching GUIDs
            List<IProduct> matchingProducts = new List<IProduct>();

            foreach (var id in ids)
            {
                var productsWithMatchingId = products.Where(p => p.Id == id);
                matchingProducts.AddRange(productsWithMatchingId);
            }

            return matchingProducts;
        }

        public void UpdateProduct(IProduct Product)
        {
            // I would make a call to a database here.
            IProduct? productItem = products.Where(p => p.Id == Product.Id).FirstOrDefault();
            if (productItem != null)
            {
                productItem = Product;
            }
        }
    }
}
