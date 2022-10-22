using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interfaces;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        /// <summary>
        /// "Create Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(Company model)
        {
            var response = await _companyService.CreateCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get All"
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _companyService.GetAll();
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By Id"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Company model)
        {
            var response = await _companyService.GetById(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);

        }
        /// <summary>
        /// "Get By Name"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(Company model)
        {
            var response = await _companyService.GetByName(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By Email"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(Company model)
        {
            var response = await _companyService.GetByEmail(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Update Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(Company model)
        {
            var response = await _companyService.UpdateCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Delete Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(Company model)
        {
            var response = await _companyService.DeleteCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }

    }
}
