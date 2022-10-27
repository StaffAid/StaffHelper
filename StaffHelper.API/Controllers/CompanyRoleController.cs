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
        public async Task<IActionResult> CreateCompanyRole(CreateCompanyRoleViewModel model)
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
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(CreateCompanyRoleViewModel model)
        {
            var response = await _companyRoleService.GetByCompanyId(model);
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
        public async Task<IActionResult> GetByRoleId(CreateCompanyRoleViewModel model)
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
        public async Task<IActionResult> UpdateCompanyRole(UpdateCompanyRoleViewModel model)
        {
            var response = await _companyRoleService.UpdateCompanyRole(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// "SoftDelete ComapanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("SoftDeleteCompanyRole")]
        public async Task<IActionResult> SoftDeleteCompanyRole(CreateCompanyRoleViewModel model)
        {
            var response = await _companyRoleService.SoftDeleteCompanyRole(model);
           
            return Ok(response);
        }

    }
}
