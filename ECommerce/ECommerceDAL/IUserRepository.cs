using ECommerceDomain;
namespace ECommerceDAL;

public interface IUserRepository {
    void AddUser(User user);
    IList<User> GetAllUser();
}