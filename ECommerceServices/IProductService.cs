using ECommerceDomain;
namespace ECommerceServices;

public interface IProductService {
    IList<Product> Get();
    Product Get(int ProductId);
}