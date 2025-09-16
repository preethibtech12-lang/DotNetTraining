namespace ECommerceDAL;
using ECommerceDomain;
using System.Text.Json;

public static class JSONHelper {

    //static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json/Products.json");
    // static string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, "Json/Products.json");
    
    public static string GetFilePath(string fileName)
    {
        return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, $"Json/{fileName}");
    }

    public static IList<T> getDataFromJsonFile<T>(string fileName) {
        var filePath = GetFilePath(fileName);
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }
        using var openStream = System.IO.File.OpenRead(filePath);
        var lists =  JsonSerializer.Deserialize<IList<T>>(openStream);
        return lists;
    }

    public static void setDataToJsonFile<T>(IList<T> lists, string fileName) {  
        var filePath = GetFilePath(fileName);   
        var jsonData =  JsonSerializer.Serialize(lists);
        File.WriteAllText(filePath, jsonData);
    }

}