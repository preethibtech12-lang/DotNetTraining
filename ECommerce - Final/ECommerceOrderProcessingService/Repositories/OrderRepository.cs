using ECommerceOrderProcessingService.Model;
using MongoDB.Driver; 
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace ECommerceOrderProcessingService.Repository;

public class OrderRepository :  IOrderRepository {
    private readonly IMongoCollection<Order> _orderCollection;

    public OrderRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
    {
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        _orderCollection = database.GetCollection<Order>("Orders");
    }
    
    public void SaveOrder(Order order) {
         _orderCollection.InsertOne(order);
    }
    
    public async Task<IList<Order>> GetOrderByUserId(string userId) {
        var result = _orderCollection.Find(p => p.UserId == userId).ToList();
        return await Task.FromResult(result);
    }
}