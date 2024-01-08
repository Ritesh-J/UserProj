using Microsoft.EntityFrameworkCore;
using UserProj.Models.Domain;

namespace UserProj.Data
{
    public class UserProjDbContext : DbContext
    {
        public UserProjDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>().HasKey(up => new
            {
                up.UserId,
                up.ProjectId
            });

            modelBuilder.Entity<UserProject>()
                .HasOne(u => u.User)
                .WithMany(up => up.UserProjects)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(u => u.Project)
                .WithMany(up => up.UserProjects)
                .HasForeignKey(u => u.ProjectId);

            //User Document 1:1 Mapping
            modelBuilder.Entity<User>()
                .HasOne(u => u.Document)
                .WithOne(d => d.User)
                .HasForeignKey<Document>(d => d.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }



    }
}
