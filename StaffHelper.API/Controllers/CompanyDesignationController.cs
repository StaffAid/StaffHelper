using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.ViewModels;
using StaffHelper.Service.Interfaces;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDesignationController : ControllerBase
    {
        private readonly ICompanyDesignationService _companyDesignationService;

        public CompanyDesignationController(ICompanyDesignationService companyDesignationService)
        {
            _companyDesignationService = companyDesignationService;
        }
        /// <summary>
        /// "Create CompanyDesignation"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateCompanyDesignation")]
        public async Task<IActionResult> CreateCompanyDesignation(CreateCompanyDesignationViewModel model)
        {
            var response = await _companyDesignationService.CreateCompanyDesignation(model);
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
            var response = await _companyDesignationService.GetAll();
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(CreateCompanyDesignationViewModel model)
        {
            var response = await _companyDesignationService.GetByCompanyId(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Update CompanyDesignation"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateCompanyDesignation")]
        public async Task<IActionResult> UpdateCompanyDesignation(UpdateCompanyDesignationViewModel model)
        {
            var response = await _companyDesignationService.UpdateCompanyDesignation(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "SoftDelete CompanyDesignation"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("SoftDeleteCompanyDesignation")]
        public async Task<IActionResult> SoftDeleteCompanyDesignation(CreateCompanyDesignationViewModel model)
        {
            var response = await _companyDesignationService.SoftDeleteCompanyDesignation(model);
            
            return Ok(response);
        }
        
    }
}
