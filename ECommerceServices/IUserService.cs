using ECommerceDomain;

namespace ECommerceServices;

public interface IUserService {    
    IList<User> GetAllUser();
    public void AddUser(User user);    
}
