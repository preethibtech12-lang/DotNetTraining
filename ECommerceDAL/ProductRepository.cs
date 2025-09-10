using ECommerceDomain;
using System.Text.Json;
using System.Linq;
namespace ECommerceDAL;

public class ProductRepository : IProductRepository
{
    public IList<Product> Get() {       
        IList<Product>? products =  getProductDataFromJsonFile();
        return products;
    }

    public Product Get(int ProductId) {        
        IList<Product>? products =  getProductDataFromJsonFile();
        var product = products.FirstOrDefault(p => p.ProductId == ProductId);
        return product;
    }

    public IList<Product> getProductDataFromJsonFile() {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json/Products.json");
        if (!System.IO.File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }  
        using var openStream = System.IO.File.OpenRead(filePath);
        var products =  JsonSerializer.Deserialize<IList<Product>>(openStream);
        return products;
    }
}
