using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.SqlServer;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Aqua.Api.IntegrationTest.Controllers;

[Collection(StringValues.DatabaseTests)]
public class DuengungControllerTestsGetAllByUserId
{
    [Fact]
    public async Task Get_all_Duengungen_By_UserId()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateTestClient()!;
        var context = application.Services.GetRequiredService<DataContext>();

        var testUser = context.AppUsers.Add(new AppUser {UserId = "Test user"});
        context.AppUsers.Add(new AppUser {UserId = "Another user"});
        var elisabeth = context.Aquarien.Add(new Aquarium
        {
            AppUser = testUser.Entity,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2)),
            Id = Guid.Empty,
            Liter = 10,
            Name = "Elisabeth",
        });

        var duengung1 = context.Duengungen.Add(new Duengung
        {
            UserId = testUser.Entity.UserId,
            AquariumId = elisabeth.Entity.Id,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2)),
            Duenger = "Eisen",
            Menge = 2,
        });

        context.Duengungen.Add(new Duengung
        {
            UserId = testUser.Entity.UserId,
            AquariumId = elisabeth.Entity.Id,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2)),
            Duenger = "Nitrat",
            Menge = 20,
        });

        context.Duengungen.Add(new Duengung
        {
            UserId = "Another User",
            AquariumId = elisabeth.Entity.Id,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2)),
            Duenger = "Eisen",
            Menge = 4,
        });

        context.SaveChanges();

        var response = await client.GetAsync("api/Duengung");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = (await response.Content.ReadFromJsonAsync<IEnumerable<DuengungDto>>())?.ToList();

        body.Should().NotBeNull();
        body.Should().HaveCount(2);

        var firstDuengung = body!.First();
        firstDuengung.Duenger.Should().Be(duengung1.Entity.Duenger);
        firstDuengung.Menge.Should().Be(duengung1.Entity.Menge);
    }
}

[Collection(StringValues.DatabaseTests)]
public class DuengerControllerTestsCreate
{
    [Fact]
    public async Task Create_Duengung()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();

        var client = application.CreateTestClient();
        var context = application.Services.GetRequiredService<DataContext>();
        var testUser = context.AppUsers.Add(new AppUser {UserId = "Test user"});

        context.AppUsers.Add(new AppUser {UserId = "Another user"});

        var aquariumEntity = context.Aquarien.Add(new Aquarium
        {
            AppUser = testUser.Entity,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2)),
            Id = Guid.Empty,
            Liter = 10,
            Name = "Elisabeth",
        });

        var aquarium = aquariumEntity.Entity;

        context.SaveChanges();
        var duengung = new
        {
            Duenger = "Eisen",
            Menge = 2,
            AquariumId = aquarium.Id,
            Datum = new DateTimeOffset(2022, 8, 8, 12, 12, 12, TimeSpan.FromHours(2))
        };

        var content = new StringContent(JsonSerializer.Serialize(duengung), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("api/Duengung", content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<DuengungDto>();

        body.Should().NotBeNull();
        body.Id.Should().NotBeEmpty();
        body.Datum.Should().Be(duengung.Datum);
        body.Aquarium.Id.Should().Be(aquarium.Id);
        body.Duenger.Should().Be(duengung.Duenger);
        body.Menge.Should().Be(duengung.Menge);
    }
}

// [Collection(StringValues.DatabaseTests)]
// public class AquariumControllerTestsDelete
// {
//     [Fact]
//     public async Task Delete_Aquarium()
//     {
//         var application = WebApplicationFactoryExctensions.CreateWebApplication();
//         var client = application.CreateClient(new WebApplicationFactoryClientOptions
//         {
//             BaseAddress = new Uri("http://localhost"),
//             AllowAutoRedirect = false
//         });
//
//         var dto = new AquariumDto(Guid.Empty, "Kurt", 1, DateTimeOffset.MinValue);
//         var response = await client.PostAsJsonAsync("api/Aquarium", dto);
//         response.StatusCode.Should().Be(HttpStatusCode.OK);
//         var postContent = await response.Content.ReadFromJsonAsync<AquariumDto>();
//
//         var resp = await client.DeleteAsync($"api/Aquarium/{postContent!.Id}");
//
//         resp.StatusCode.Should().Be(HttpStatusCode.OK);
//         var content = await resp.Content.ReadAsStringAsync();
//         Guid.Parse(content.Replace("\"", "")).Should().Be(postContent.Id.ToString());
//     }
// }
//
// [Collection(StringValues.DatabaseTests)]
// public class AquariumControllerTestsGetValues
// {
//     [Fact]
//     public async Task Anlegung_eines_Aquarium()
//     {
//         var application = WebApplicationFactoryExctensions.CreateWebApplication();
//         var client = application.CreateTestClient();
//         var context = application.Services.GetRequiredService<DataContext>();
//         context.AppUsers.Add(new AppUser {UserId = "Test user"});
//         var aquariumId = Guid.NewGuid();
//         var aquariumIdElisabeth = Guid.NewGuid();
//         context.Aquarien.AddRange(
//             new Aquarium
//             {
//                 Datum = DateTimeOffset.Now,
//                 Liter = 55,
//                 Name = "Kurt",
//                 UserId = "Test user",
//                 Id = aquariumId
//             },
//             new Aquarium
//             {
//                 Datum = DateTimeOffset.Now,
//                 Liter = 15,
//                 Name = "Elisabeth",
//                 UserId = "Test user",
//                 Id = aquariumIdElisabeth
//             }
//         );
//         context.Messungen.AddRange(
//             new Messung
//             {
//                 Id = Guid.NewGuid(),
//                 AquariumId = aquariumId,
//                 UserId = "Test user",
//                 Datum = new DateTimeOffset(2022, 4, 1, 12, 10, 10, TimeSpan.FromHours(2)),
//                 Wert = "KH",
//                 Menge = 47.2
//             },
//             new Messung
//             {
//                 Id = Guid.NewGuid(),
//                 AquariumId = aquariumIdElisabeth,
//                 UserId = "Test user",
//                 Datum = new DateTimeOffset(2022, 5, 1, 12, 10, 10, TimeSpan.FromHours(2)),
//                 Wert = "KH",
//                 Menge = 41.2
//             },
//             new Messung
//             {
//                 Id = Guid.NewGuid(),
//                 AquariumId = aquariumId,
//                 UserId = "Test user",
//                 Datum = new DateTimeOffset(2022, 5, 1, 12, 10, 10, TimeSpan.FromHours(2)),
//                 Wert = "KH",
//                 Menge = 41.2
//             },
//             new Messung
//             {
//                 Id = Guid.NewGuid(),
//                 AquariumId = aquariumId,
//                 UserId = "Test user",
//                 Datum = new DateTimeOffset(2022, 4, 1, 11, 10, 10, TimeSpan.FromHours(2)),
//                 Wert = "GH",
//                 Menge = 4.2
//             });
//         await context.SaveChangesAsync();
//         var messungen =
//             await client.GetFromJsonAsync<AquariumMessungenDto>($"api/Aquarium/{aquariumId}/Messungen");
//         messungen.Should().NotBeNull();
//         messungen.Timestamps.Should().HaveCount(2);
//     }
// }