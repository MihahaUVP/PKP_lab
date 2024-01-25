using EDA_Yukhansson.Aggregates;
using EDA_Yukhansson.Events;
using EDA_Yukhansson.kafka;
using System.Text.Json;

namespace EDA_Yukhansson.Queries
{
    public class EmployeeQuery
    {

        public EmployeeQuery() 
        {
            Console.WriteLine("Вы произвели вызов EmployeeQuery");
        }
        public Employee Execute()
        {
            KafkaConsumer consumer = new KafkaConsumer();
            var events = consumer.ConsumeAllMessages();
            Employee employee = new Employee();
            for(int i = 0;i<events.Count;i++)
            {
                Console.WriteLine(events[i]);
                SalaryEvent? salaryEvent = JsonSerializer.Deserialize<SalaryEvent>(events[i]);
                if ((salaryEvent?.isUp)==true)
                {
                    employee.Salary += salaryEvent.SalaryChange;
                }
                // employee.Salary += salaryEvent.SalaryChange;
                if ((salaryEvent?.isUp) == false)
                {
                    employee.Salary -= salaryEvent.SalaryChange;
                }
            }
            
            return employee;
        }
    }
}
