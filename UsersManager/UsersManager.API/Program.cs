using Microsoft.EntityFrameworkCore;
using UsersManager.BLL.Services;
using UsersManager.Core.Repositories;
using UsersManager.Core.Services;
using UsersManager.DAL;
using UsersManager.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// JSON seetings
var configs = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add db context
builder.Services.AddDbContext<UsersManagerContext>(o => o.UseMySql(
    configs.GetConnectionString("UsersManagerContext"),
    ServerVersion.Parse("8.0.29-mysql")));

// add custom services and repos
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

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
