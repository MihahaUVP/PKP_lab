using EDA_Yukhansson.Events;
using EDA_Yukhansson.kafka;
using System.Text.Json;

namespace EDA_Yukhansson.Commands
{
    public class SalaryUpCommand
    {
            public SalaryUpCommand()
            {

                Console.WriteLine("Зарплата повысилась!");
            }
            public async Task SendAsync()
            {
                SalaryEvent salaryUpEvent = new SalaryEvent("Misha", 10);
                KafkaProducer kafkaProducer = new KafkaProducer();
                var message = JsonSerializer.Serialize(salaryUpEvent);
                await kafkaProducer.SendAsync(message);
            }
    }
}
