using ECommerceOrderProcessingService.Model;
using ECommerceOrderProcessingService.Repository;
namespace ECommerceOrderProcessingService.Service;

public class OrderService : IOrderService {
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void SaveOrder(Order order) {
        _orderRepository.SaveOrder(order);
    }
    
    public async Task<IList<Order>> GetOrderByUserId(string userId) {
        IList<Order> orders =  await _orderRepository.GetOrderByUserId(userId);
        return orders;
    }
}