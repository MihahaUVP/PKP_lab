namespace EDA_Yukhansson.Aggregates
{
    public class Employee
    {
        public Employee()
        {
            Name = "Name1";
            Salary = 100;
            Position = "StartPosition";
        }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Position {  get; set; }
    }
}
