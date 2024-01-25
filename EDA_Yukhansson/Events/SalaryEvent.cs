namespace EDA_Yukhansson.Events
{
    public class SalaryEvent
    {
        public SalaryEvent(string EmployeeName, int SalaryChange, bool isUp = true)
        {
            this.SalaryChange = SalaryChange;
            this.EmployeeName = EmployeeName;
            this.isUp = isUp;
        }
        public string EmployeeName { get; set; }
        public int SalaryChange { get; set; }
        public bool isUp { get; set; }
    }
}
