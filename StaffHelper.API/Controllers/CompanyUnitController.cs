using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interfaces;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUnitController : ControllerBase
    {
        private readonly ICompanyUnitService _companyUnitService;

        public CompanyUnitController(ICompanyUnitService companyUnitService)
        {
            _companyUnitService = companyUnitService;
        }

        /// <summary>
        /// "Create CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateCompanyUnit")]
        public async Task<IActionResult> CreateCompanyUnit(CompanyUnit model)
        {
            var response = await _companyUnitService.CreateCompanyUnit(model);
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
            var response = await _companyUnitService.GetAll();
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompany")]
        public async Task<IActionResult> GetByCompany(CompanyUnit model)
        {
            var response = await _companyUnitService.GetByCompany(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Get By ComapanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(CompanyUnit model)
        {
            var response = await _companyUnitService.GetByCompanyId(model);
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
        public async Task<IActionResult> GetByName(CompanyUnit model)
        {
            var response = await _companyUnitService.GetByName(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Update CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateCompanyUnit")]
        public async Task<IActionResult> UpdateCompanyUnit(CompanyUnit model)
        {
            var response = await _companyUnitService.UpdateCompanyUnit(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Delete CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCompanyUnit")]
        public async Task<IActionResult> DeleteCompanyUnit(CompanyUnit model)
        {
            var response = await _companyUnitService.DeleteCompanyUnit(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }




    }
}
