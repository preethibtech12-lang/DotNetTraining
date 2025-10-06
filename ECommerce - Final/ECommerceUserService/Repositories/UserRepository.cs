using MongoDB.Driver; 
using ECommerceUserService.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
namespace ECommerceUserService.Repository;

public class UserRepository : IUserRepository {

    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
    {
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        _userCollection = database.GetCollection<User>("Users");
    }
    public async Task<User> GetById(int id) {
         var result = _userCollection.Find(u => u.UserId == id).FirstOrDefault();
         return await Task.FromResult(result);
    }

    public async Task<IList<User>> GetAll() {
        var result = _userCollection.Find(u => true).ToList();;
        return await Task.FromResult(result);
    }

    public void AddUser(User user){
         _userCollection.InsertOne(user);
    }

    public void UpdateUser(User user) {
         _userCollection.ReplaceOne(u => u.UserId == user.UserId, user);
    }

    public void DeleteUser(int userId) {
         _userCollection.DeleteOne(u => u.UserId == userId);
    }

}