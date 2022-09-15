using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Aqua.Api.IntegrationTest.Controllers;

[Collection(StringValues.DatabaseTests)]
public class MessungControllerTests_Get_Messungen
{
    [Fact]
    public async Task Abfrage_der_Messungen()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateTestClient();
        
        var appUser = new AppUser
        {
            UserId = "Test user"
        };

        var aquarium = new Aquarium
        {
            Liter = 20,
            Name = "Elisabeth",
            UserId = "Test user"
        };
        
        var context = application.Services.GetRequiredService<DataContext>();
        context.AppUsers.Add(appUser);
        context.Aquarien.Add(aquarium);
        await context.SaveChangesAsync();

        var aquarien = await client.GetFromJsonAsync<List<AquariumDto>>("api/Aquarium");
        var aquariumDto = aquarien.First();

        var messung = new
            { Wert = "Foo", Menge = 2, appUser = "Test user", AquariumId = aquariumDto.Id, Datum = DateTimeOffset.Now};
        var stringContent = new StringContent(JsonSerializer.Serialize(messung), Encoding.UTF8, "application/json");
        var messungResponse = await client.PostAsync("api/Messung", stringContent);
    }
}
