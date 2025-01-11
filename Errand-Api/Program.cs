using Errand_Api.Models;
using Errand_Api.Schemas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RoutingDb>(opt => opt.UseInMemoryDatabase("Routing"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Enable API Explorer
builder.Services.AddEndpointsApiExplorer();
//Add Swagger OpenAPI Document generator
builder.Services.AddOpenApiDocument(config => {
    config.DocumentName = "Errand-Api";
    config.Title = "Errand-Api v0";
    config.Version = "V0";
});

var app = builder.Build();

app.MapPost("/desitnationslist", async (DestinationsList destinations, RoutingDb Db) =>
{
    Db.DestinationsList.Add(destinations);
    await Db.SaveChangesAsync();

    return Results.Created($"/destinationslist/{destinations.Id}", destinations);
});

app.MapGet("/getdestlist{id}", async (int id, RoutingDb db) =>
    await db.DestinationsList.FindAsync(id)
        is DestinationsList destinationsList
            ? Results.Ok(destinationsList)
            : Results.NotFound());

//enable swagger
if(app.Environment.IsDevelopment()){
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Errand-Api";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}


app.MapGet("/", () => "Hello World!");

app.Run();
