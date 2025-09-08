using ECommerceDomain;
namespace ECommerceServices;

public interface IProductService {
    IList<Product> Get();
}