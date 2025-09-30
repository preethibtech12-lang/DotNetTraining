using ECommerceDomain;
namespace ECommerceDAL;

public interface IProductRepository {
    IList<Product> Get();
    Product Get(int ProductId);
    void SaveProduct(Product Product);
    void UpdateProduct(Product Product);    
    void DeleteProduct(int ProductId);
}