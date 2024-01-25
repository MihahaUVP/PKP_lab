using EDA_Yukhansson.Events;
using EDA_Yukhansson.kafka;
using System.Text.Json;

namespace EDA_Yukhansson.Commands
{
    public class SalaryDownCommand
    {
        public SalaryDownCommand()
        {
            Console.WriteLine("Зарплата понижена!");
        }
        public async Task SendAsync()
        {
            SalaryEvent salaryDownEvent = new SalaryEvent("Misha",10,false);
            KafkaProducer kafkaProducer = new KafkaProducer();
            var message = JsonSerializer.Serialize(salaryDownEvent);
            await kafkaProducer.SendAsync(message);
        }
    }
}
