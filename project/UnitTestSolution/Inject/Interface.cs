namespace Inject;

public class Order
{
    public int OrderId { get; set; }
    public required string Product { get; set; }
    public decimal Amount { get; set; }
}

public class PaymentDetails
{
    public required string PaymentMethod { get; set; }
}

public interface IOrderRepository
{
    void Save(Order order);
    Order? Get(int orderId);
}

public interface IPaymentProcessor
{
    bool ProcessPayment(Order order, PaymentDetails paymentDetails);
}

public interface INotificationService
{
    void NotifyCustomer(Order order, string message);
}
