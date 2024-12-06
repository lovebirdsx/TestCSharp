namespace Inject;

public class OrderService(IOrderSaver orderSaver, IPaymentProcessor paymentProcessor, INotificationService notificationService)
{
    private readonly IOrderSaver _orderSaver = orderSaver;
    private readonly IPaymentProcessor _paymentProcessor = paymentProcessor;
    private readonly INotificationService _notificationService = notificationService;

    public void CreateOrder(Order order, PaymentDetails paymentDetails)
    {
        _orderSaver.Save(order);
        bool paymentSuccess = _paymentProcessor.ProcessPayment(order, paymentDetails);
        if (paymentSuccess)
        {
            _notificationService.NotifyCustomer(order, "您的订单已成功创建并支付！");
        }
        else
        {
            _notificationService.NotifyCustomer(order, "支付失败，请重试。");
        }
    }
}
