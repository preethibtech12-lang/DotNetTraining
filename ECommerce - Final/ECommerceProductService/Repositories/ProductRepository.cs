using MongoDB.Driver; 
using ECommerceProductService.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace ECommerceProductService.Repository;

public class ProductRepository : IProductRepository {

    private readonly IMongoCollection<Product> _productCollection;

    public ProductRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
    {
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        _productCollection = database.GetCollection<Product>("Products");
    }
    public async Task<Product> GetProductById(int id) {
         var result = _productCollection.Find(p => p.ProductId == id).FirstOrDefault();
         return await Task.FromResult(result);
    }

    public async Task<IList<Product>> GetAllProduct() {
        var result = _productCollection.Find(p => true).ToList();;
        return await Task.FromResult(result);
    }

    public void SaveProduct(Product product){
         _productCollection.InsertOne(product);
    }

    public void UpdateProduct(Product product) {
         _productCollection.ReplaceOne(p => p.ProductId == product.ProductId, product);
    }

    public void DeleteProduct(int ProductId) {
         _productCollection.DeleteOne(p => p.ProductId == ProductId);
    }

}