using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.SqlServer;
using FluentAssertions;
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
            {Wert = "Foo", Menge = 2, appUser = "Test user", AquariumId = aquariumDto.Id, Datum = DateTimeOffset.Now};
        var stringContent = new StringContent(JsonSerializer.Serialize(messung), Encoding.UTF8, "application/json");
        var messungResponse = await client.PostAsync("api/Messung", stringContent);
        messungResponse.Should().NotBeNull();
        messungResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

[Collection(StringValues.DatabaseTests)]
public class MessungenControllerTests_GetMesswerteByAquariumId
{
    [Fact]
    public async Task Abfrage_der_Messwerte_anhand_der_AquariumId()
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
        context.Messungen.AddRange(new[]
        {
            new Messung
            {
                AquariumId = aquarium.Id,
                Datum = DateTimeOffset.Now,
                Menge = 6.4,
                UserId = appUser.UserId,
                Wert = "PH"
            },
            new Messung
            {
                AquariumId = aquarium.Id,
                Datum = DateTimeOffset.Now,
                Menge = 3,
                UserId = appUser.UserId,
                Wert = "KH"
            },
            new Messung
            {
                AquariumId = aquarium.Id,
                Datum = DateTimeOffset.Now,
                Menge = 2,
                UserId = appUser.UserId,
                Wert = "KH"
            }
        });

        await context.SaveChangesAsync();


        var messungResponse =
            await client.GetFromJsonAsync<AquariumMesswerteDto>($"api/Messung/{aquarium.Id}/Messwerte");

        messungResponse.Should().NotBeNull();
        messungResponse.Werte.Should().HaveCount(2);
        messungResponse.Werte.Should().Contain("PH", "KH");
    }

    [Collection(StringValues.DatabaseTests)]
    public class MessungenControllerTests_GetMesswerteByAquariumIdByMesswert
    {
        [Fact]
        public async Task Abfrage_von_Messungen_anhand_der_AquariumId_und_des_Messwerts()
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

            var aquarium2 = new Aquarium
            {
                Liter = 30,
                Name = "Kurt",
                UserId = "Test user"
            };

            var context = application.Services.GetRequiredService<DataContext>();
            context.AppUsers.Add(appUser);
            context.Aquarien.Add(aquarium);
            context.Aquarien.Add(aquarium2);
            context.Messungen.AddRange(new[]
            {
                new Messung
                {
                    AquariumId = aquarium.Id,
                    Datum = DateTimeOffset.Now,
                    Menge = 6.4,
                    UserId = appUser.UserId,
                    Wert = "PH"
                },
                new Messung
                {
                    AquariumId = aquarium.Id,
                    Datum = new DateTimeOffset(2022, 12, 13, 10, 12, 0, TimeSpan.Zero),
                    Menge = 3,
                    UserId = appUser.UserId,
                    Wert = "KH"
                },
                new Messung
                {
                    AquariumId = aquarium2.Id,
                    Datum = DateTimeOffset.Now,
                    Menge = 6,
                    UserId = appUser.UserId,
                    Wert = "KH"
                },
                new Messung
                {
                    AquariumId = aquarium.Id,
                    Datum = new DateTimeOffset(2022, 12, 12, 10, 12, 0, TimeSpan.Zero),
                    Menge = 2,
                    UserId = appUser.UserId,
                    Wert = "KH"
                }
            });

            await context.SaveChangesAsync();


            var messungResponse =
                await client.GetFromJsonAsync<AquariumMessungenWerteDto>($"api/Messung/{aquarium.Id}/Messungen/KH");

            messungResponse.Should().NotBeNull();
            messungResponse.Messungen.Should().HaveCount(2);
            var messung1 = messungResponse.Messungen.First();
            var messung2 =messungResponse.Messungen.Last();
            messung1.Item2.Should().Be(2);
            messung2.Item2.Should().Be(3);
            messungResponse.Messwert.Should().Be("KH");
        }
    }
}