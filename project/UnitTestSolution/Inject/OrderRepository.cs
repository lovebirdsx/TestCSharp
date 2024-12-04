namespace Inject;

public class OrderRepository : IOrderRepository
{
    readonly List<Order> _allOrders = [];

    public OrderRepository()
    {
        _allOrders.Add(new Order { OrderId = 1, Product = "A", Amount = 100 });
        _allOrders.Add(new Order { OrderId = 2, Product = "B", Amount = 200 });
        _allOrders.Add(new Order { OrderId = 3, Product = "C", Amount = 300 });
    }

    public Order? Get(int orderId)
    {
        return _allOrders.FirstOrDefault(x => x.OrderId == orderId);
    }

    public void Save(Order order)
    {
        var existingOrder = _allOrders.FirstOrDefault(x => x.OrderId == order.OrderId);
        if (existingOrder != null)
        {
            _allOrders.Remove(existingOrder);
        }
        _allOrders.Add(order);
    }
}
