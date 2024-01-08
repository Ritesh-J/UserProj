using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProj.Models.Domain;
using UserProj.Models.DTO;
using UserProj.Repository;

namespace UserProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectController : ControllerBase
    {
        private readonly IUserProjectRepository userProjectRepository;

        public UserProjectController(IUserProjectRepository userProjectRepository)
        {
            this.userProjectRepository = userProjectRepository;
        }

        [HttpPost]
        public IActionResult AssignUserProject([FromBody] UserProjectRequestDto requestDto)
        {
            var userProject=userProjectRepository.AssignUserProject(requestDto);
            if (userProject == null) { return NotFound("User or Project Not Found"); }
            return Ok(userProject);
        }

        [HttpGet]
        public IActionResult GetALlUserProjectMapping()
        {
            List<UserProjectResponseDto> userProjs=userProjectRepository.GetAllUserProjectMapping();
            return Ok(userProjs);
        }
    }
}
