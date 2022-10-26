using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
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
        public async Task<IActionResult> CreateCompany(CreateCompanyViewModel model)
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
        /// "Get By RcNo"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByRcNo")]
        public async Task<IActionResult> GetByRcNo(CreateCompanyViewModel model)
        {
            var response = await _companyService.GetByRcNo(model);
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
        public async Task<IActionResult> GetByName(CreateCompanyViewModel model)
        {
            var response = await _companyService.GetByName(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By Address"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByAddress")]
        public async Task<IActionResult> GetByAddress(CreateCompanyViewModel model)
        {
            var response = await _companyService.GetByAddress(model);
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
        public async Task<IActionResult> UpdateCompany(UpdateCompanyViewModel model)
        {
            var response = await _companyService.UpdateCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "SoftDelete Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("SoftDeleteCompany")]
        public async Task<IActionResult> SoftDeleteCompany(CreateCompanyViewModel model)
        {
            var response = await _companyService.SoftDeleteCompany(model);

            return Ok(response);
        }

    }
}
