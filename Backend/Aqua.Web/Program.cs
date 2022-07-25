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

await fac.Subscribe("192.168.2.103", 1883, "TEMP/DS18B20/hagen", (string mess) =>
{
    Console.WriteLine(mess);
    hub.Clients.All.SendAsync("Notify", mess);
});


Console.WriteLine("MQTT client subscribed to topic.");
Console.WriteLine("Press enter to exit.");

app.UseEndpoints(endpoints => { endpoints.MapHub<SignalrHub>("/hub"); });
await app.RunAsync();