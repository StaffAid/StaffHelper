using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interface;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeServiceController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeServiceController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("CreateProfile")]
        public async Task<IActionResult> Createprofile(Employee employee)
        {
            var result = await _employeeService.CreateProfile(employee);
            return Ok(result);
        }
        [HttpDelete("DeleteProfile")]
        public async Task<IActionResult> DeleteProfile(Employee employee)
        {
            var result = await _employeeService.DeleteProfile(employee);
            return Ok(result);
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(Employee employee)
        {
            var result = await _employeeService.UpdateProfile(employee);
            return Ok(result);
        }
        [HttpGet("SearchProfile")]
        public IActionResult SearchProfile(Employee employee)
        {
            var result = _employeeService.SearchProfile(employee);
            return Ok(result);
        }
    }
}
