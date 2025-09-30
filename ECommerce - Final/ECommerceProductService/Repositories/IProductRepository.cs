using ECommerceProductService.Model;
namespace ECommerceProductService.Repository;

public interface IProductRepository {
    Task<Product> GetProductById(int id);
    Task<IList<Product>> GetAllProduct();
    void SaveProduct(Product Product);
    void UpdateProduct(Product Product);    
    void DeleteProduct(int ProductId);
}