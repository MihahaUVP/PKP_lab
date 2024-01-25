namespace EDA_Yukhansson.Events
{
    public class SalaryDownEvent
    {
        public SalaryDownEvent(string EmployeeName, int SalaryDown) 
        { 
            this.SalaryDown = SalaryDown;
            this.EmployeeName = EmployeeName;
        }
        public string EmployeeName { get; set; }
        public int SalaryDown { get; set; }
    }
}
