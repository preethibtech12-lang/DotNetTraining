using ECommerceDomain;
namespace ECommerceServices;

public interface IProductService {
    IList<Product> Get();
    Product Get(int ProductId);
    void SaveProduct(Product Product);
    void UpdateProduct(Product Product);
    void DeleteProduct(int ProductId);
}