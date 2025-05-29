using Microsoft.EntityFrameworkCore;
using Task4_WebUsersAPI.Models;
using Task4_WebUsersAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to Db

builder.Services.AddDbContext<UserDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("UserDB");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}
);

// Adding the Services to be used by the Controllers

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LogInService>();

// Everything you add has to be before the line below
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
