using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ECommerceProductService.Model;
public class Product
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    
    [BsonElement("ProductId")]
    public int ProductId {get; set;} 

    [BsonElement("Name")]
    public string Name {get; set;} = String.Empty;

    [BsonElement("Description")]
    public string Description {get; set;} = String.Empty;
}