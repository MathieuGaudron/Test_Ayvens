using TestVoitures.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Véhicules AYVENS",
        Version = "v1",
        Description = "Test technique AYVENS — endpoints GET/DELETE avec données mockées."
    });
});

builder.Services.AddSingleton<IVehiculeRepository, InMemoryVehiculeRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
