// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Mqtt.ServR.Controllers;
using MQTTnet.AspNetCore;

Console.WriteLine("Hello, World!");
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenAnyIP(1833, l => l.UseMqtt());
    opt.ListenAnyIP(8000);
});

builder.Services.AddControllers();
builder.Services.AddHostedMqttServer(
    optionsBuilder => { optionsBuilder.WithDefaultEndpoint(); });

builder.Services.AddMqttConnectionHandler();
builder.Services.AddConnections();

builder.Services.AddSingleton<MqttController>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapConnectionHandler<MqttConnectionHandler>(
        "/mqtt",
        options => options.WebSockets.SubProtocolSelector = protocolList =>
            protocolList.FirstOrDefault() ?? string.Empty);
});
var mqttController = app.Services.GetRequiredService<MqttController>();
app.UseMqttServer(server =>
{
    server.ValidatingConnectionAsync += mqttController.ValidateConnection;
    server.ClientConnectedAsync += mqttController.OnClientConnected;
});
app.Run();