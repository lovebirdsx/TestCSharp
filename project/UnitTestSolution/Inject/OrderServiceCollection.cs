using Microsoft.Extensions.DependencyInjection;

namespace Inject;

public class OrderServiceCollection
{
    public static ServiceProvider CreateProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IOrderRepository, OrderRepository>();
        
        // 确保 IOrderSaver 的实现是 IOrderRepository
        serviceCollection.AddSingleton<IOrderSaver>(provider => provider.GetRequiredService<IOrderRepository>());

        serviceCollection.AddSingleton<INotificationService, NotificationService>();
        serviceCollection.AddSingleton<IPaymentProcessor, PaymentProcessor>();
        serviceCollection.AddSingleton<OrderService>();

        var provider = serviceCollection.BuildServiceProvider();
        return provider;
    }
}
