using Microsoft.EntityFrameworkCore;
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

app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext context) =>
{
    var exceptionFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
    var error = exceptionFeature?.Error;

    // Return a generic error response
    context.Response.StatusCode = 500;
    context.Response.ContentType = "application/json";
    return Results.Problem(
        statusCode: 500,
        title: "An unexpected error occurred.",
        detail: error?.ToString() // Only show details in dev
    );
});

app.Run();
