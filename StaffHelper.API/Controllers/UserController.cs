using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffHelper.Model.ViewModels;
using StaffHelper.Service.Interfaces;
using System.Threading.Tasks;

namespace StaffHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// "Create User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            var response = await _userService.CreateUser(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "GetAll"
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();
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
        public async Task<IActionResult> GetByName(CreateUserViewModel model)
        {
            var response = await _userService.GetByName(model);
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
        public async Task<IActionResult> GetByAddress(CreateUserViewModel model)
        {
            var response = await _userService.GetByAddress(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "Update User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {
            var response = await _userService.UpdateUser(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }
        /// <summary>
        /// "SoftDelete User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("SoftDelete")]
        public async Task<IActionResult> SoftDelete(CreateUserViewModel model)
        {
            var response = await _userService.SoftDelete(model);
           
             return Ok(response);
        }
    }
}
