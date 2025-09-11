using ECommerceDAL;
using ECommerceDomain;
namespace ECommerceServices;

public class ProductService(IProductRepository _productRepository) : IProductService
{
    public IList<Product> Get() {
        return _productRepository.Get();
    }
    public Product Get(int ProductId) {
        return _productRepository.Get(ProductId);
    }
    public void SaveProduct(Product Product) {
        _productRepository.SaveProduct(Product);
    }
    public void UpdateProduct(Product Product) {
        _productRepository.UpdateProduct(Product);
    }
    public void DeleteProduct(int ProductId) {
        _productRepository.DeleteProduct(ProductId);
    }
}
