using Moq;

namespace Inject.Tests;


public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_PaymentSuccess_ShouldNotifyCustomer()
    {
        // Arrange
        var mockRepository = new Mock<IOrderRepository>();
        var mockPaymentProcessor = new Mock<IPaymentProcessor>();
        var mockNotificationService = new Mock<INotificationService>();

        var order = new Order { Product = "Book", Amount = 29.99M };
        var paymentDetails = new PaymentDetails { PaymentMethod = "PayPal" };

        mockPaymentProcessor.Setup(p => p.ProcessPayment(order, paymentDetails)).Returns(true);

        var orderService = new OrderService(mockRepository.Object, mockPaymentProcessor.Object, mockNotificationService.Object);

        // Act
        orderService.CreateOrder(order, paymentDetails);

        // Assert
        mockNotificationService.Verify(n => n.NotifyCustomer(order, "您的订单已成功创建并支付！"), Times.Once);
        mockRepository.Verify(r => r.Save(order), Times.Once);
        mockPaymentProcessor.Verify(p => p.ProcessPayment(order, paymentDetails), Times.Once);
    }

    [Fact]
    public void CreateOrder_PaymentFailure_ShouldNotifyCustomer()
    {
        // Arrange
        var mockRepository = new Mock<IOrderRepository>();
        var mockPaymentProcessor = new Mock<IPaymentProcessor>();
        var mockNotificationService = new Mock<INotificationService>();

        var order = new Order { Product = "Laptop", Amount = 999.99M };
        var paymentDetails = new PaymentDetails { PaymentMethod = "PayPal" };

        mockPaymentProcessor.Setup(p => p.ProcessPayment(order, paymentDetails)).Returns(false);

        var orderService = new OrderService(mockRepository.Object, mockPaymentProcessor.Object, mockNotificationService.Object);

        // Act
        orderService.CreateOrder(order, paymentDetails);

        // Assert
        mockNotificationService.Verify(n => n.NotifyCustomer(order, "支付失败，请重试。"), Times.Once);
        mockRepository.Verify(r => r.Save(order), Times.Once);
        mockPaymentProcessor.Verify(p => p.ProcessPayment(order, paymentDetails), Times.Once);
    }
}

