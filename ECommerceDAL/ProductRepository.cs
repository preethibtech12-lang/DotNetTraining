using ECommerceDomain;
namespace ECommerceDAL;

public class ProductRepository : IProductRepository
{
    public IList<Product> Get() {
        return new List<Product>
        {
            new Product
            {
                Name = "HP Laptop",
                Description = "HP Laptop Description"
            },
            new Product
            {
                Name = "Dell Laptop",
                Description = "Dell Laptop Description"
            },
            new Product
            {
                Name = "Mac Book",
                Description = "Mac Book Description"
            }
        };
    }
}
