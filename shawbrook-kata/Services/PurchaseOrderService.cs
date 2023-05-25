using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Enums;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShippingService _shippingService;

        public PurchaseOrderService(
            ICustomerService customerService,
            IPurchaseOrderRepository purchaseOrderRepository,
            IProductRepository productRepository,
            IShippingService shippingService)
        {
            _customerService = customerService;
            _purchaseOrderRepository = purchaseOrderRepository;
            _productRepository = productRepository;
            _shippingService = shippingService;
        }

        public async Task<IPurchaseOrder?> ProcessPurchaseOrder(List<Guid> purchaseItems)
        {
            // It may be a good idea to refactor this method for simplicity and also
            // incorproate some level of transactions so that reads/writes don't save prematurely 
            try
            {
                List<IProduct> retrievedProducts = _productRepository.RetrieveProducts(purchaseItems);
                if (retrievedProducts.Count < 1)
                {
                    return null;
                }
                IPurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.CustomerId = _customerService.GetCustomerId();
                purchaseOrder.PurchaseOrderId = Guid.NewGuid();

                IShipping shipping = new Shipping();

                ICustomer? customer = await _customerService.GetCustomer(purchaseOrder.CustomerId)!;

                if (customer == null)
                {
                    return null;
                }

                purchaseOrder.Items = new List<string>();
                shipping.PhysicalProducts = new List<IProduct>();

                foreach (var product in retrievedProducts)
                {
                    purchaseOrder.Items.Add(product.Title);
                    purchaseOrder.Total += product.Price;

                    if (product.PhysicalItem)
                    {
                        shipping.PhysicalProducts.Add(product);
                    }

                    if (product.Type == CategoriesEnum.Categories.Membership.ToString() && !customer.CategoryAccess.Contains(product.Type))
                    {
                        customer.CategoryAccess.Add(product.Type);
                    }
                }

                if (shipping.PhysicalProducts.Count > 0)
                {
                    shipping.TrackingNumber = _shippingService.GenerateShippingLabel(customer!);
                }

                await _purchaseOrderRepository.CreatePurchaseOrder(purchaseOrder);

                customer.PurchaseHistory.Add(purchaseOrder);

                await _customerService.UpdateCustomer(customer);

                return purchaseOrder;
            }
            catch (Exception)
            {
                // Log error
                return null;
            }
        }
    }
}
