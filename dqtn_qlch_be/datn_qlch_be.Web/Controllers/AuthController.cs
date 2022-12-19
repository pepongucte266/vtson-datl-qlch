using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        #region Fields
        readonly IEmployeeService _service;
        #endregion

        #region Constructor
        public AuthController(IEmployeeService service) 
        {
            _service = service;
        }
        #endregion


        [HttpPost("register"), Authorize(Roles = "Quản trị hệ thống")]
        public async Task<ActionResult<Employee>> RegisterEmployee(EmployeeDto request)
        {

            Employee employee = _service.RegisterEmployee(request);
            if(employee.PasswordSalt == null || employee.PasswordHash == null)
            {
                return BadRequest(employee);
            }
            return Ok(employee);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(EmployeeDto request)
        {
            return Ok(_service.Login(request));
        }

        [HttpGet("profile")]
        public ActionResult<Employee> getCurrentEmployrr()
        {
            return Ok(_service.GetCurrentEmployee());
        }

    }
}
