using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
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
        public async Task<IActionResult> CreateCompanyUnit(CreateCompanyUnitViewModel model)
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
        /// "Get By ComapanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(CreateCompanyUnitViewModel model)
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
        public async Task<IActionResult> GetByName(CreateCompanyUnitViewModel model)
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
        public async Task<IActionResult> UpdateCompanyUnit(UpdateCompanyUnitViewModel model)
        {
            var response = await _companyUnitService.UpdateCompanyUnit(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "SoftDelete CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("SoftDeleteCompanyUnit")]
        public async Task<IActionResult> SoftDeleteCompanyUnit(CreateCompanyUnitViewModel model)
        {
            var response = await _companyUnitService.SoftDeleteCompanyUnit(model);

             return Ok(response);
        }




    }
}
