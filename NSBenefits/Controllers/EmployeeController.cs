using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSBenefits.DTOs;

namespace NSBenefits.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            var result = new List<EmployeeDto>();

            result.Add(new EmployeeDto
            {
                FirstName = "Bob",
                LastName = "Smith",
                Salary = 2000,
                Dependents = new List<DependentDto>
                {
                    new DependentDto
                    {
                        FirstName = "Andy",
                        LastName = "Smith"
                    }
                }
            });

            result.Add(new EmployeeDto
            {
                FirstName = "Aaron",
                LastName = "Thompson",
                Salary = 2000,
                Dependents = new List<DependentDto>
                {
                    new DependentDto
                    {
                        FirstName = "Mary",
                        LastName = "Thompson"
                    }
                }
            });

            return result;
        }
    }
}
