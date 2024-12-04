using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentHouse.Application;
using RentHouse.Persistence;
using System.Text;
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

    c.SwaggerDoc("Auth", new OpenApiInfo
    {
        Title = "Auth API",
        Version = "v1",
        Description = "Operations related to Auth"
    });

    c.DocInclusionPredicate((groupName, apiDesc) =>
    {
        var group = apiDesc.GroupName;
        return string.Equals(group, groupName, StringComparison.OrdinalIgnoreCase);
    });
});

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/RentHouse/swagger.json", "RentHouse API");
        c.SwaggerEndpoint("/swagger/Statistics/swagger.json", "Statistics API");
        c.SwaggerEndpoint("/swagger/Auth/swagger.json", "Auth API");

    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
