using ECommerceDomain;
namespace ECommerceDAL;

public class UserRepository : IUserRepository {

    string fileName = "Users.json";
    public IList<User> GetAllUser() {
        return JSONHelper.getDataFromJsonFile<User>(fileName);
    }   

    public void AddUser(User user) {
        IList<User>? users =  JSONHelper.getDataFromJsonFile<User>(fileName);
        var existingPasswords = users.Select(u => u.Password).ToHashSet();
        int newPassword;
        var rng = new Random();
        do
        {
            newPassword = rng.Next(1000, 10000); // 4-digit number
        }
        while (existingPasswords.Contains(newPassword.ToString()));
        user.Password = newPassword.ToString();    
        users.Add(user);
        JSONHelper.setDataToJsonFile<User>(users, fileName);
    }
}