using ECommerceOrderProcessingService.Model;
namespace ECommerceOrderProcessingService.Repository;

public interface IOrderRepository {
    void SaveOrder(Order order);
    Task<IList<Order>> GetOrderByUserId(string userId);
}