using MQTTnet.Server;

namespace Mqtt.ServR.Controllers;

    sealed class MqttController
    {
        public MqttController()
        {
            // Inject other services via constructor.
        }
        
        public Task OnClientConnected(ClientConnectedEventArgs eventArgs)
        {
            Console.WriteLine($"Client '{eventArgs.ClientId}' connected.");
            Console.WriteLine($"User '{eventArgs.UserName}' connected.");
            
            return Task.CompletedTask;
        }


        public Task ValidateConnection(ValidatingConnectionEventArgs eventArgs)
        {
            Console.WriteLine($"Client '{eventArgs.ClientId}' wants to connect. Accepting!");
            return Task.CompletedTask;
        }
        
    }