namespace ECommerceDAL;
using ECommerceDomain;
using System.Text.Json;

public static class JSONHelper {

    //static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json/Products.json");
    static string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, "Json/Products.json");
    public static IList<Product> getDataFromJsonFile() {
        using var openStream = System.IO.File.OpenRead(filePath);
        var products =  JsonSerializer.Deserialize<IList<Product>>(openStream);
        return products;
    }

     public static void setDataToJsonFile(IList<Product> products) {     
        var productList =  JsonSerializer.Serialize(products);
        File.WriteAllText(filePath, productList);
    }

}