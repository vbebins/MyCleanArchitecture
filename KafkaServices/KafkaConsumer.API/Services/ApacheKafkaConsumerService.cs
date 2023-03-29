using Confluent.Kafka;
using KafkaConsumer.API.Model;
using System.Diagnostics;
using System.Text.Json;

namespace KafkaConsumer.API.Services
{
    public class ApacheKafkaConsumerService : IHostedService
    {
        private readonly string topic = "MyFirstTopic";
        private readonly string groupId = "MyFirstTopic_group";
        private readonly string bootstrapServers = "localhost:9092";

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(topic);
                    var cancelToken = new CancellationTokenSource();

                    try
                    {
                        while (true)
                        {
                            Console.WriteLine($"Executing Consumer Here");

                            var consumer = consumerBuilder.Consume
                               (cancelToken.Token);

                            Console.WriteLine($"Reached Consumer Here");

                            var orderRequest = JsonSerializer.Deserialize
                                <OrderProcessingRequest>
                                    (consumer.Message.Value);
                            if (orderRequest != null)
                                Console.WriteLine($"Processing Order Result: {orderRequest.Status}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    
    }
}
