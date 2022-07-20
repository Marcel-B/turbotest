using System.Text;
using Aqua.Web;
using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IClientFactory, ClientFactory>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());
app.UseRouting();
app.UseStaticFiles();
app.UseDefaultFiles();

app.MapFallbackToController("Index", "Fallback");

var hub = app.Services.GetRequiredService<IHubContext<SignalrHub>>();
var fac = app.Services.GetRequiredService<IClientFactory>();

await fac.Subscribe("127.0.0.1", 1833, "foo/bar", (Foo? mess) =>
{
    Console.WriteLine(mess.Name);
    hub.Clients.All.SendAsync("Notify", mess.Name);
});


Console.WriteLine("MQTT client subscribed to topic.");
Console.WriteLine("Press enter to exit.");

app.UseEndpoints(endpoints => { endpoints.MapHub<SignalrHub>("/hub"); });
await app.RunAsync();