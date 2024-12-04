namespace Inject;

public class NotificationService : INotificationService
{
    public void NotifyCustomer(Order order, string message)
    {
        Console.WriteLine($"Notifying customer about order {order.OrderId} with message: {message}");
    }
}
