using EmployeeManagement.Contracts.Services;
using EmployeeManagement.Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("employee-list")]
        //[Authorize]
        public async Task<IActionResult> GetEmployeeList([FromQuery] DTOGetEmployeeList model)
        {
            var result = await _employeeService.GetEmployeeList(model);
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost("add-employee")]
        public async Task<IActionResult> Post([FromBody] DTOAddEmployee model)
        {
            var result = await _employeeService.AddEmployee(model);
            return Ok(result);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);

        }
    }
}
