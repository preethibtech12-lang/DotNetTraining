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
}
