using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.SqlServer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Aqua.Api.IntegrationTest.Controllers;

[Collection(StringValues.DatabaseTests)]
public class AquariumControllerTestsGet
{
    [Fact]
    public async Task Get_Aquarium_By_Id()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateTestClient()!;

        var kurt = new AquariumDto(Guid.Empty, "Kurt", 1, DateTimeOffset.MinValue);
        var kurtContent = new StringContent(JsonSerializer.Serialize(kurt), Encoding.UTF8, "application/json");

        var kurtResponse = await client.PostAsync("api/Aquarium", kurtContent);
        kurtResponse.StatusCode.Should().Be(HttpStatusCode.OK);


        var elisabeth = new AquariumDto(Guid.Empty, "Elisabeth", 5, DateTimeOffset.MinValue);

        var elisabethContent =
            new StringContent(JsonSerializer.Serialize(elisabeth), Encoding.UTF8, "application/json");
        var elisabethResponse = await client.PostAsync("api/Aquarium", elisabethContent);

        elisabethResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var response = await client.GetAsync("api/Aquarium");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = (await response.Content.ReadFromJsonAsync<IEnumerable<AquariumDto>>())?.ToList();
        body.Should().NotBeNull();
        body.Should().HaveCount(2);
        var firstResult = body!.First();
        var firstResultUpdated = firstResult with {Liter = 2};

        var updateResponse = await client.PutAsJsonAsync($"api/Aquarium/{firstResult.Id}", firstResultUpdated);
        updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var updatedResult = await updateResponse.Content.ReadFromJsonAsync<AquariumDto>();
        updatedResult.Should().NotBeNull();
        updatedResult!.Id.Should().Be(firstResult.Id);
        updatedResult.Liter.Should().Be(2);
        updatedResult.Name.Should().Be(firstResult.Name);
    }
}

[Collection(StringValues.DatabaseTests)]
public class AquariumControllerTestsCreate
{
    [Fact]
    public async Task Create_Aquarium()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateTestClient();

        var dto = new AquariumDto(Guid.Empty, "Kurt", 1, DateTimeOffset.MinValue);
        var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("api/Aquarium", content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<AquariumDto>();

        body.Should().NotBeNull();
        body.Datum.Should().BeBefore(DateTimeOffset.Now);
        body.Id.Should().NotBeEmpty();
        body.Liter.Should().Be(1);
        body.Name.Should().Be("Kurt");
    }
}

[Collection(StringValues.DatabaseTests)]
public class AquariumControllerTestsDelete
{
    [Fact]
    public async Task Delete_Aquarium()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost"),
            AllowAutoRedirect = false
        });

        var dto = new AquariumDto(Guid.Empty, "Kurt", 1, DateTimeOffset.MinValue);
        var response = await client.PostAsJsonAsync("api/Aquarium", dto);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var postContent = await response.Content.ReadFromJsonAsync<AquariumDto>();

        var resp = await client.DeleteAsync($"api/Aquarium/{postContent!.Id}");

        resp.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await resp.Content.ReadAsStringAsync();
        Guid.Parse(content.Replace("\"", "")).Should().Be(postContent.Id.ToString());
    }
}

[Collection(StringValues.DatabaseTests)]
public class AquariumControllerTestsGetValues
{
    [Fact]
    public async Task Anlegung_eines_Aquarium()
    {
        var application = WebApplicationFactoryExctensions.CreateWebApplication();
        var client = application.CreateTestClient();
        var context = application.Services.GetRequiredService<DataContext>();
        context.AppUsers.Add(new AppUser {UserId = "Test user"});
        var aquariumId = Guid.NewGuid();
        var aquariumIdElisabeth = Guid.NewGuid();
        context.Aquarien.AddRange(
            new Aquarium
            {
                Datum = DateTimeOffset.Now,
                Liter = 55,
                Name = "Kurt",
                UserId = "Test user",
                Id = aquariumId
            },
            new Aquarium
            {
                Datum = DateTimeOffset.Now,
                Liter = 15,
                Name = "Elisabeth",
                UserId = "Test user",
                Id = aquariumIdElisabeth
            }
        );
        context.Messungen.AddRange(
            new Messung
            {
                Id = Guid.NewGuid(),
                AquariumId = aquariumId,
                UserId = "Test user",
                Datum = new DateTimeOffset(2022, 4, 1, 12, 10, 10, TimeSpan.FromHours(2)),
                Wert = "KH",
                Menge = 47.2
            },
            new Messung
            {
                Id = Guid.NewGuid(),
                AquariumId = aquariumIdElisabeth,
                UserId = "Test user",
                Datum = new DateTimeOffset(2022, 5, 1, 12, 10, 10, TimeSpan.FromHours(2)),
                Wert = "KH",
                Menge = 41.2
            },
            new Messung
            {
                Id = Guid.NewGuid(),
                AquariumId = aquariumId,
                UserId = "Test user",
                Datum = new DateTimeOffset(2022, 5, 1, 12, 10, 10, TimeSpan.FromHours(2)),
                Wert = "KH",
                Menge = 41.2
            },
            new Messung
            {
                Id = Guid.NewGuid(),
                AquariumId = aquariumId,
                UserId = "Test user",
                Datum = new DateTimeOffset(2022, 4, 1, 11, 10, 10, TimeSpan.FromHours(2)),
                Wert = "GH",
                Menge = 4.2
            });
        await context.SaveChangesAsync();
        var messungen =
            await client.GetFromJsonAsync<AquariumMessungenDto>($"api/Aquarium/{aquariumId}/Messungen");
        messungen.Should().NotBeNull();
        messungen.Messungen.Should().HaveCount(2);
    }
}