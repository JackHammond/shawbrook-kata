using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Repository;
using shawbrook_kata.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IShippingService, ShippingService>();
builder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();

// These are singletons only because I want to persist some data during runtime instead of using a real database
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
