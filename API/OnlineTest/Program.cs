using Microsoft.EntityFrameworkCore;
using OnlineTest.Models;
using OnlineTest.Services.Interfaces;
using OnlineTest.Services.Services;
using OnlineTest.Models.Interfaces;
using OnlineTest.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineTestConnString"), b => b.MigrationsAssembly("OnlineTest.Models"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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