using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProj.Models.Domain;
using UserProj.Models.DTO;
using UserProj.Repository;

namespace UserProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectRequestDto requestDto)
        {
            var project=projectRepository.CreateProject(requestDto);
            return Ok(project);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProjectById([FromRoute] int id)
        {
            var project = projectRepository.GetProjectById(id);
            if (project == null) { return NotFound(); }
            return Ok(project);
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            List<Project> projects = projectRepository.GetAllProject();
            return Ok(projects);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProject([FromRoute] int id, [FromBody] ProjectRequestDto requestDto)
        {
            var project = projectRepository.UpdateProject(id, requestDto);
            if (project == null) { return NotFound(); }
            return Ok(project);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProject([FromRoute] int id)
        {
            var project = projectRepository.DeleteProject(id);
            if (project == null) { return NotFound(); }
            return Ok();
        }
    }
}
