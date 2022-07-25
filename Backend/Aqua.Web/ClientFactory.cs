using System.Text;
using System.Text.Json;
using MQTTnet;
using MQTTnet.Client;

namespace Aqua.Web;

public class Foo
{
    public float Name { get; set; }
}

public interface IClientFactory
{
    Task Subscribe<T>(string ip, int port, string topic, Action<T?> messageReceived);
    MqttClientSubscribeOptions GetOptions(string topic);
}

public class ClientFactory : IClientFactory
{
    private MqttFactory mqttFactory;
    private IMqttClient mqttClient;

    public ClientFactory()
    {
        mqttFactory = new MqttFactory();
    }


    public MqttClientSubscribeOptions GetOptions(string topic)
    {
        return mqttFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(f => { f.WithTopic(topic); })
            .Build();
    }

    public async Task Subscribe<T>(string ip, int port, string topic, Action<T?> messageReceived)
    {
        var mqttClient = mqttFactory.CreateMqttClient();


        mqttClient.ApplicationMessageReceivedAsync += e =>
        {
            Console.WriteLine("Get Result");
            var result = e.ApplicationMessage.Payload;
            if (result is not null)
            {
                var json = Encoding.UTF8.GetString(result);
                Console.WriteLine(json);
                var res = JsonSerializer.Deserialize<T>(json);
                messageReceived.Invoke(res);
            }

            return Task.CompletedTask;
        };

        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer(ip, port)
            .Build();

        await mqttClient.ConnectAsync(mqttClientOptions);
        await mqttClient.SubscribeAsync(GetOptions(topic), CancellationToken.None);
    }
}