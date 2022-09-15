using com.marcelbenders.Aqua.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aqua.Api.IntegrationTest.Controllers;

public static class WebApplicationFactoryExctensions
{
    internal static WebApplicationFactory<Program> CreateWebApplication(bool memoryDb = false)
        => new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("IntegrationTests");
                builder.ConfigureServices(services =>
                {
                    services.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "Test", options => { });
                    if (memoryDb)
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                        services.Remove(descriptor);
                        services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=test.db"));
                    }

                    var provider = services.BuildServiceProvider();
                    using var scope = provider.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<DataContext>();
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                });
            });

    internal static HttpClient? CreateTestClient(this WebApplicationFactory<Program> applicationFactory)
        => applicationFactory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost"),
            AllowAutoRedirect = false
        });
}