using UserProj.Data;
using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public class ProjectRepositoryImpl : IProjectRepository
    {
        private readonly UserProjDbContext dbContext;

        public ProjectRepositoryImpl(UserProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Project CreateProject(ProjectRequestDto requestDto)
        {
            var project = new Project
            {
                Name = requestDto.Name,

            };
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return project;
        }

        public Project? DeleteProject(int Id)
        {
            var project=dbContext.Projects.FirstOrDefault(x => x.Id == Id);
            if (project == null) return null;
            dbContext.Remove(project);
            dbContext.SaveChanges();
            return project;
        }

        public List<Project>? GetAllProject()
        {
            return dbContext.Projects.ToList();
        }

        public Project? GetProjectById(int Id)
        {
            var project= dbContext.Projects.FirstOrDefault(x => x.Id==Id);
            if (project == null) return null;
            return project;
        }

        public Project? UpdateProject(int Id, ProjectRequestDto requestDto)
        {
            var existingProject = dbContext.Projects.FirstOrDefault(x => x.Id == Id);
            if (existingProject == null) return null;
            existingProject.Name= requestDto.Name;
            dbContext.SaveChanges();
            return existingProject;

        }
    }
}
