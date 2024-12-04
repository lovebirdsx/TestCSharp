namespace Inject;

public class PaymentProcessor : IPaymentProcessor
{
    public bool ProcessPayment(Order order, PaymentDetails paymentDetails)
    {
        if (paymentDetails.PaymentMethod == "CreditCard")
        {
            Console.WriteLine($"Processing payment for order {order.OrderId} using Credit Card");
            return true;
        }
        else if (paymentDetails.PaymentMethod == "PayPal")
        {
            Console.WriteLine($"Processing payment for order {order.OrderId} using PayPal");
            return true;
        }
        else
        {
            Console.WriteLine($"Unknown payment method {paymentDetails.PaymentMethod}");
            return false;
        }
    }
}
