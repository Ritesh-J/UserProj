using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProj.Models.Domain;
using UserProj.Models.DTO;
using UserProj.Repository;

namespace UserProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequestDto userRequestDto) { 
            var user=userRepository.CreateUser(userRequestDto);
            return Ok(user);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById([FromRoute] int id) { 
            var user=userRepository.GetUserById(id);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers() {
            List<User> users=userRepository.GetAllUser();
            return Ok(users);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserRequestDto requestDto) {
            var user=userRepository.UpdateUser(id, requestDto);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = userRepository.DeleteUser(id);
            if (user == null) { return NotFound(); }
            return Ok();
        }
    }
}
