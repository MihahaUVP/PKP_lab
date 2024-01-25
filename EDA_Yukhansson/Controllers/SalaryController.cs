using EDA_Yukhansson.Aggregates;
using EDA_Yukhansson.Commands;
using EDA_Yukhansson.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDA_Yukhansson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            
            EmployeeQuery employeeQuery = new EmployeeQuery();
            Employee employee = employeeQuery.Execute();
            return Ok(employee);
        }
        [HttpPost("api/salaryUp")]
        public async Task<IActionResult> SalaryUp()
        {
            SalaryUpCommand command = new SalaryUpCommand();
            await command.SendAsync();
            return Ok();
        }
        [HttpPost("api/salaryDown")]
        public async Task<IActionResult> SalaryDown()
        {
            
            SalaryDownCommand command = new SalaryDownCommand();
            await command.SendAsync();
            return Ok();
        }
    }

}
