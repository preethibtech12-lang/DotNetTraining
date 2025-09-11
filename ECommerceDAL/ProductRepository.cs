using ECommerceDomain;
using System.Linq;
namespace ECommerceDAL;

public class ProductRepository : IProductRepository
{
    public IList<Product> Get() {       
        return JSONHelper.getDataFromJsonFile();
    }
    public Product Get(int ProductId) {        
        IList<Product>? products =  JSONHelper.getDataFromJsonFile();
        var product = products.FirstOrDefault(p => p.ProductId == ProductId);
        return product;
    }    
    public void SaveProduct(Product Product){
        IList<Product>? products =  JSONHelper.getDataFromJsonFile();
        products.Add(Product);
        JSONHelper.setDataToJsonFile(products);
    }
    public void UpdateProduct(Product ProductToUpdate) {
        IList<Product>? products =  JSONHelper.getDataFromJsonFile();
        var existingProduct = products.FirstOrDefault(p => p.ProductId == ProductToUpdate.ProductId);
        if(existingProduct != null) {
            products.Remove(existingProduct);
            products.Add(ProductToUpdate);
        }        
        JSONHelper.setDataToJsonFile(products);
    }
    public void DeleteProduct(int ProductId) {
        IList<Product>? products =  JSONHelper.getDataFromJsonFile();
        var existingProduct = products.FirstOrDefault(p => p.ProductId == ProductId);
        if(existingProduct != null) {
            products.Remove(existingProduct);
        }        
        JSONHelper.setDataToJsonFile(products);
    }
}
