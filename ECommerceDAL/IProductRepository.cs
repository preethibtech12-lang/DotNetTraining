using ECommerceDomain;
namespace ECommerceDAL;

public interface IProductRepository {
    IList<Product> Get();
    Product Get(int ProductId);
}