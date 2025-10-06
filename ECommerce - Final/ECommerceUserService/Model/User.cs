
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace ECommerceUserService.Models;

public class User
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }

    [BsonElement("userid")]
    public int UserId { get; set; }

    [BsonElement("firstname")]
    public string FirstName { get; set; }

    [BsonElement("lastname")]
    public string LastName { get; set; }

    [BsonElement("username")]
    public string UserName { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }

    [BsonElement("role")]
    public string Role { get; set; }
    public string Token { get; set; }
}
