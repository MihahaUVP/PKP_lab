using Confluent.Kafka;
using EDA_Yukhansson.Aggregates;
using EDA_Yukhansson.Events;
using System.Diagnostics.Contracts;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Confluent.Kafka.ConfigPropertyNames;

namespace EDA_Yukhansson.kafka
{
    public class KafkaConsumer
    {
        const string topic = "salary-kafka";
        const string groupId = "groupId";
        const string bootstrapServers = "localhost:9092";

        ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

      //  private readonly IServiceProvider _serviceProvider;

        public KafkaConsumer() 
        {
           // _serviceProvider = serviceProvider;
            //Console.WriteLine("Консьюмер работает!");
        }
        public IList<string> ConsumeAllMessages()
        {
            

            //Console.WriteLine("Метод ConsumeAllMessages");
            IList<string> messages = new List<string>();

            using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
            consumerBuilder.Subscribe(topic);
            var cancelToken = new CancellationTokenSource();


            var consumer = consumerBuilder.Consume(300);

            try
            {
                while (consumer != null)
                {
                    messages.Add(consumer.Message.Value);
                    consumer = consumerBuilder.Consume(300);    
                }
            }
            catch (OperationCanceledException)
                {
                    Console.WriteLine("Вылетает!!");
                    consumerBuilder.Close();
                }
          
            finally { consumerBuilder.Close(); }
            return messages;
        }
        


        ///TODO: Сделать чтение всех событий из кафка
        
    }
}
