using ECommerceOrderProcessingService.Model;
namespace ECommerceOrderProcessingService.Service;

public interface IOrderService {
  void SaveOrder(Order Order);
  IList<Order> GetOrderByUserId(string userId);
}