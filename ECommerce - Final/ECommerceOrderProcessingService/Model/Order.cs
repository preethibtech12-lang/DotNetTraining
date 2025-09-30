namespace ECommerceOrderProcessingService.Model;

public class Order {
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public List<string> ProductIds { get; set; }

}