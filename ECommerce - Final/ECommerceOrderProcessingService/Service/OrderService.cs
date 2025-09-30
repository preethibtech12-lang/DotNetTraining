using ECommerceOrderProcessingService.Model;
using ECommerceOrderProcessingService.Repository;
namespace ECommerceOrderProcessingService.Service;

public class OrderService : IOrderService {
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void SaveOrder(Order Order) {

    }
    
    public IList<Order> GetOrderByUserId(string userId) {
        return new List<Order>();
    }
}