using Confluent.Kafka;
using System.Net;
using System.Text.Json;

namespace EDA_Yukhansson.kafka
{
    public class KafkaProducer
    {
        const string topic = "salary-kafka";
        const string groupId = "test_group";
        const string bootstrapServers = "localhost:9092";

        //private readonly IServiceProvider _serviceProvider;

        public KafkaProducer()
        {

        }
        public async Task<bool> SendAsync(string message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };
            try
            {
                using var producer = new ProducerBuilder<Null, string>(config).Build();

                var result = await producer.ProduceAsync(topic, new Message<Null, string>
                {
                    Value = message
                });
                Console.WriteLine(message);
                Console.WriteLine(result.Timestamp.UtcDateTime);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
            return await Task.FromResult(false);
        }
    }
}
