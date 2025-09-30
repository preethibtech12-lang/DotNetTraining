using ECommerceProductService.Model;
using ECommerceProductService.Repository;
using System.Linq;
namespace ECommerceProductService.Service;

public class ProductService : IProductService {

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetProductById(int id) {
      Product products =  await _productRepository.GetProductById(id);
      return products;
    }

    public async Task<IList<Product>> GetAllProduct() {
      IList<Product> products = await _productRepository.GetAllProduct();
      return products;
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