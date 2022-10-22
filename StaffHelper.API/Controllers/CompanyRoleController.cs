using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interfaces;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRoleController : ControllerBase
    {
        private readonly ICompanyRoleService _companyRoleService;

        public CompanyRoleController(ICompanyRoleService companyRoleService)
        {
            _companyRoleService = companyRoleService;
        }

        /// <summary>
        /// "Create CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateCompanyRole")]
        public async Task<IActionResult> CreateCompanyRole(CompanyRole model)
        {
            var response = await _companyRoleService.CreateCompanyRole(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get All"
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _companyRoleService.GetAll();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get By Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompany")]
        public async Task<IActionResult> GetByCompany(CompanyRole model)
        {
            var response = await _companyRoleService.GetByCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(CompanyRole model)
        {
            var response = await _companyRoleService.GetByCompanyId(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
      
        /// <summary>
        /// "Get By Role"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByRole")]
        public async Task<IActionResult> GetByRole(CompanyRole model)
        {
            var response = await _companyRoleService.GetByRole(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Get By RoleId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByRoleId")]
        public async Task<IActionResult> GetByRoleId(CompanyRole model)
        {
            var response = await _companyRoleService.GetByRoleId(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Update CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateCompanyRole")]
        public async Task<IActionResult> UpdateCompanyRole(CompanyRole model)
        {
            var response = await _companyRoleService.UpdateCompanyRole(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "Delete ComapanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCompanyRole")]
        public async Task<IActionResult> DeleteCompanyRole(CompanyRole model)
        {
            var response = await _companyRoleService.DeleteCompanyRole(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
