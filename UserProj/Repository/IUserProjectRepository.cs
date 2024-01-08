using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public interface IUserProjectRepository
    {
        UserProject AssignUserProject(UserProjectRequestDto requestDto);
        List<UserProjectResponseDto> GetAllUserProjectMapping();
        
    }
}
