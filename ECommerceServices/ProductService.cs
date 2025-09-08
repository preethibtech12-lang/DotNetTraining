using ECommerceDAL;
using ECommerceDomain;
namespace ECommerceServices;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository; 
    public ProductService(IProductRepository productRepository) {
        _productRepository = productRepository;
    }
    public IList<Product> Get() {
        return _productRepository.Get();
    }
}
