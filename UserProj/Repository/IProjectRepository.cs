using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public interface IProjectRepository 
    {
        Project CreateProject(ProjectRequestDto requestDto);
        Project? GetProjectById(int Id);
        List<Project>? GetAllProject();
        Project? UpdateProject(int Id, ProjectRequestDto requestDto);
        Project? DeleteProject(int Id);
    }
}
