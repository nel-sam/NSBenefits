using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using NSBenefits.DTOs;

namespace NSBenefits.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IEmployeeService employeeService)
        {
            this._logger = logger;
            this._employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            var employees = this._employeeService.GetAll();

            var result = employees.Select(e => new EmployeeDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary,
                Dependents = e.Dependents?.Select(d => new DependentDto
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName
                })
            });

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            if (employee == null) {
                return BadRequest();
            }

            // TODO: Add more validation such as verifying name is not junk

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary
            };

            this._employeeService.Create(newEmployee);
            return Ok();
        }
    }
}
