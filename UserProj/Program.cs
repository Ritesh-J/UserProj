using Microsoft.EntityFrameworkCore;
using UserProj.Data;
using UserProj.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserProjDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("UserProjConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IProjectRepository, ProjectRepositoryImpl>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepositoryImpl>();
builder.Services.AddScoped<IUserProjectRepository, UserProjectRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
