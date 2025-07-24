using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WalksAPI.Data;
using WalksAPI.Mappings;
using WalksAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddDbContext<WalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WalksConnection")));

// Registering the repository
builder.Services.AddScoped<WalksAPI.Repositories.IRegionRepository, WalksAPI.Repositories.SQLRegionRepository>();
builder.Services.AddScoped<WalksAPI.Repositories.IWalkRepository, WalksAPI.Repositories.SQLWalkRepository>();

//AutoMapper Injection services
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
