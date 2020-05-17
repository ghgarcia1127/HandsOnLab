using System.Collections.Generic;
using System.Threading.Tasks;
using HandsOnLab.Core.Dto;
using HandsOnLab.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var result = await employeeService.GetAllEmployeeAsync().ConfigureAwait(false);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Employee> Find(int id)
        {
            var result = await employeeService.FindEmployeeAsync(id).ConfigureAwait(false);
            return result;
        }
    }
}
