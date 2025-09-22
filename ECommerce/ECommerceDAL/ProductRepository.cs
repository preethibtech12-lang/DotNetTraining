using ECommerceDomain;
using System.Linq;
namespace ECommerceDAL;

public class ProductRepository : IProductRepository
{
    string fileName = "Products.json";
    public IList<Product> Get() {       
        return JSONHelper.getDataFromJsonFile<Product>(fileName);
    }
    public Product Get(int ProductId) {        
        IList<Product>? products =  JSONHelper.getDataFromJsonFile<Product>(fileName);
        var product = products.FirstOrDefault(p => p.ProductId == ProductId);
        return product;
    }    
    public void SaveProduct(Product Product){
        IList<Product>? products =  JSONHelper.getDataFromJsonFile<Product>(fileName);
        products.Add(Product);
        JSONHelper.setDataToJsonFile<Product>(products, fileName);
    }
    public void UpdateProduct(Product ProductToUpdate) {
        IList<Product>? products =  JSONHelper.getDataFromJsonFile<Product>(fileName);
        var existingProduct = products.FirstOrDefault(p => p.ProductId == ProductToUpdate.ProductId);
        if(existingProduct != null) {
            products.Remove(existingProduct);
            products.Add(ProductToUpdate);
        }        
        JSONHelper.setDataToJsonFile<Product>(products, fileName);
    }
    public void DeleteProduct(int ProductId) {
        IList<Product>? products =  JSONHelper.getDataFromJsonFile<Product>(fileName);
        var existingProduct = products.FirstOrDefault(p => p.ProductId == ProductId);
        if(existingProduct != null) {
            products.Remove(existingProduct);
        }        
        JSONHelper.setDataToJsonFile<Product>(products, fileName);
    }
}
