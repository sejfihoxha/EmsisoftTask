using EmsisoftTask.Data.Entities;
using EmsisoftTask.Data.Repositories.Hashes;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace EmsisoftTask.Worker.Consumer
{
    public class RabitMqConsumer : IHostedService
    {
        private IHashRepository _hashRepository;
        public RabitMqConsumer(IHashRepository hashRepository)
        {
            _hashRepository = hashRepository;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };

                var connection = factory.CreateConnection();

                using var channel = connection.CreateModel();
                //declare the queue after mentioning name and a few property related to that
                channel.QueueDeclare("hash", exclusive: false);

                //Set Event object which listen message from chanel which is sent by producer
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Hash message received: {message}");

                    var hash = JsonSerializer.Deserialize<Hash>(message);

                    _hashRepository.Add(hash);
                };
                //read the message
                channel.BasicConsume(queue: "hash", autoAck: true, consumer: consumer);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
