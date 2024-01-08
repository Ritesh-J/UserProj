using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public interface IUserRepository
    {
        User CreateUser(UserRequestDto requestDto);
        User? GetUserById(int id);
        List<User> GetAllUser();
        User? UpdateUser(int id, UserRequestDto userRequestDto);
        User? DeleteUser(int id);
    }
}
