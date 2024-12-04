using Microsoft.Extensions.DependencyInjection;

namespace Inject;

public class OrderServiceCollection
{
    public static ServiceProvider CreateProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IOrderRepository, OrderRepository>();
        serviceCollection.AddSingleton<INotificationService, NotificationService>();
        serviceCollection.AddSingleton<IPaymentProcessor, PaymentProcessor>();
        serviceCollection.AddSingleton<OrderService>();

        var provider = serviceCollection.BuildServiceProvider();
        return provider;
    }
}
