using Microsoft.EntityFrameworkCore;
using Newton.VideoGameCatalogue.Server;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Uses XML documentation in swagger.
builder.Services.AddSwaggerGen(options =>
{
    string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string fullXmlFileName = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    options.IncludeXmlComments(fullXmlFileName);
});

// Connects to Game Catalogue DB in SQL server.
builder.Services.AddDbContext<GameContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("GameCatalogueConnection"))
    .EnableSensitiveDataLogging()
);

// Allow Angular app to access the API.
var corsPolicyName = "AllowAngularApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Use the CORS policy.
app.UseCors(corsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//// Disable CORS since angular will be running on port 4200 and the service on port 5258.
//app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
