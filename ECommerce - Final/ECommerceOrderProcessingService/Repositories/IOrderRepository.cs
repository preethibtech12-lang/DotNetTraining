using ECommerceOrderProcessingService.Model;
namespace ECommerceOrderProcessingService.Repository;

public interface IOrderRepository {
    void SaveOrder(Order Order);
    IList<Order> GetOrderByUserId(string userId);
}