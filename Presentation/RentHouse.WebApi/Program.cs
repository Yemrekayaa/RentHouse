using Microsoft.OpenApi.Models;
using RentHouse.Application;
using RentHouse.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("RentHouse", new OpenApiInfo
    {
        Title = "RentHouse API",
        Version = "v1",
        Description = "Operations related to RentHouse"
    });

    c.SwaggerDoc("Statistics", new OpenApiInfo
    {
        Title = "Statistics API",
        Version = "v1",
        Description = "Operations related to Statistics"
    });

    c.DocInclusionPredicate((groupName, apiDesc) =>
    {
        var group = apiDesc.GroupName;
        return string.Equals(group, groupName, StringComparison.OrdinalIgnoreCase);
    });
});

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/RentHouse/swagger.json", "RentHouse API");
        c.SwaggerEndpoint("/swagger/Statistics/swagger.json", "Statistics API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
