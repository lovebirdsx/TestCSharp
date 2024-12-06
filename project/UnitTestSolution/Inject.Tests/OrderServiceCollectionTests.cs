using Microsoft.Extensions.DependencyInjection;

namespace Inject.Tests;

public class OrderServiceCollectionTests
{
    [Fact]
    public void GetServiceCollection()
    {
        var provider = OrderServiceCollection.CreateProvider();
        Assert.NotNull(provider);
    }

    [Fact]
    public void MakeOrder() 
    {
        var provider = OrderServiceCollection.CreateProvider();
        var orderService = provider.GetRequiredService<OrderService>();
        Assert.NotNull(orderService);

        orderService.CreateOrder(new Order { Product = "Book", Amount = 29.99M }, new PaymentDetails { PaymentMethod = "PayPal" });
    }

    [Fact]
    public void ServiceTheSame()
    {
        var provider = OrderServiceCollection.CreateProvider();
        var orderSaver = provider.GetRequiredService<IOrderSaver>();
        var orderRepository = provider.GetRequiredService<IOrderRepository>();

        Assert.Same(orderSaver, orderRepository);
    }
}
