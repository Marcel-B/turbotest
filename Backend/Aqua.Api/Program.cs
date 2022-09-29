using com.marcelbenders.Aqua.Api.ErrorHandler;
using com.marcelbenders.Aqua.Application;
using com.marcelbenders.Aqua.SqlServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAquaApplication();

var configuration = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration));

builder.Configuration.AddEnvironmentVariables();
var authority = builder.Configuration["Authority"];

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = authority;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false,
        };
    });
builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(authority);
        options.UseAspNetCore();
        options.UseSystemNetHttp();
    });

var app = builder.Build();

var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<DataContext>();
context.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

var origins = builder.Configuration["Cors"];

var logger = app.Logger;

logger.LogInformation("{Origins}", origins);

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors(options =>
{
    options
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(origins);
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();