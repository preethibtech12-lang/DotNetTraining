using ECommerceUserService.Models;
namespace ECommerceUserService.Repository;

public interface IUserRepository {
    Task<User> GetById(int id);
    Task<IList<User>> GetAll();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}