using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PlantMonitorAPI;
using PlantMonitorAPI.Database; // Add this using directive if needed

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureServices();
builder.Services.ConfigureRequests();
// builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure the DbContext with PostgreSQL
builder.Services.AddDbContext<PlantMonitorDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
