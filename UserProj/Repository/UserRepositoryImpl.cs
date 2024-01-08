using System.Net.WebSockets;
using UserProj.Data;
using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public class UserRepositoryImpl : IUserRepository

    {
        private readonly UserProjDbContext dbContext;

        public UserRepositoryImpl(UserProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public User CreateUser(UserRequestDto requestDto)
        {
            var User = new User
            {
                Name = requestDto.Name,
                Email = requestDto.Email,
                Password = requestDto.Password,
                PhoneNumber = requestDto.PhoneNumber,
                DocumentId=requestDto.DocumnetId
            };
            dbContext.Users.Add(User);
            dbContext.SaveChanges();
            return User;
        }

        public User? DeleteUser(int id)
        {
            var user=dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) { return null; }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges() ;
            return user;


        }

        public List<User> GetAllUser()
        {
            List<User> users = dbContext.Users.ToList();
            return users;
        }

        public User? GetUserById(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) { return null; }
            return user;
        }

        public User? UpdateUser(int id, UserRequestDto userRequestDto)
        {
            var existingUser = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (existingUser == null) { return null; }
            existingUser.Name = userRequestDto.Name;
            existingUser.Email = userRequestDto.Email;
            existingUser.PhoneNumber= userRequestDto.PhoneNumber;
            existingUser.PhoneNumber=userRequestDto.PhoneNumber;
            existingUser.DocumentId = userRequestDto.DocumnetId;
            dbContext.SaveChanges();
            return existingUser;
        }
    }
}
