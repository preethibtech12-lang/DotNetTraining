using ECommerceOrderProcessingService.Model;
namespace ECommerceOrderProcessingService.Repository;

public class OrderRepository :  IOrderRepository {
    public void SaveOrder(Order Order) {

    }
    
    public IList<Order> GetOrderByUserId(string userId) {
        return new List<Order>();
    }
}