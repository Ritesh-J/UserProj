using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UserProj.Data;
using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public class UserProjectRepositoryImpl : IUserProjectRepository
    {
        private readonly UserProjDbContext dbContext;

        public UserProjectRepositoryImpl(UserProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UserProject AssignUserProject(UserProjectRequestDto requestDto)
        {
            var user = dbContext.Users.Find(requestDto.UserId);
            var project = dbContext.Projects.Find(requestDto.ProjectId);
            if (user == null || project == null)
                return null;
            var userProject = new UserProject
            {
                User = user,
                Project = project
 
            
            };
            dbContext.UserProjects.Add(userProject);
            dbContext.SaveChanges();
            return userProject;
        }

        public List<UserProjectResponseDto> GetAllUserProjectMapping()
        {
            List<UserProject> userProjects=dbContext.UserProjects.ToList();
            List<UserProjectResponseDto> userProjectResponseDtos = new List<UserProjectResponseDto>();
            foreach (var userProject in userProjects)
            {
                var user=dbContext.Users.Find(userProject.UserId);
                var project=dbContext.Projects.Find(userProject.ProjectId);
                UserProjectResponseDto userProjectResponseDto = new UserProjectResponseDto
                {
                    ProjectId = userProject.ProjectId,
                    UserId = userProject.UserId,
                    UserName = user.Name,
                    ProjectName = project.Name
                };
                userProjectResponseDtos.Add(userProjectResponseDto);
            }
            return userProjectResponseDtos;
        }
    }
}
