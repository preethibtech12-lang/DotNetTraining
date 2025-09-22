using ECommerceDomain;
using ECommerceDAL;
namespace ECommerceServices;

public class UserService(IUserRepository _userRepository) : IUserService
{
    public IList<User> GetAllUser() {
        return _userRepository.GetAllUser();
    }
    public void AddUser(User user){
        _userRepository.AddUser(user);
    }
}