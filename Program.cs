using DotNetEnv; 
using Microsoft.EntityFrameworkCore;
using Studying.Context;
using Studying.Mapper;
using Studying.Models;
using Studying.Repository;
using Studying.Repository.Interface;
using Studying.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
builder.Configuration.AddEnvironmentVariables();

#region DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region AddingServicesToContainer
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

#region RegistrandoServiços
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HasherService>();
builder.Services.AddHttpClient<Studying.Services.NewsService>();
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//Console.WriteLine("Connection String: " + builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();
