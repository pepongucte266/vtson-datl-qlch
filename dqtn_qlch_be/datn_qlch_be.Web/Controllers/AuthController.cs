using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


        [HttpPost("register")]
        public async Task<ActionResult<Employee>> RegisterEmployee(EmployeeDto request)
        {

            Employee employee = _service.RegisterEmployee(request);
            
            return Ok(employee);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login(EmployeeDto request)
        //{
        //    var checkPassword = _service.VerifiPassword(request.Password, employee.PasswordHash, employee.PasswordSalt);
        //    if(!checkPassword)
        //    {
        //        return BadRequest("Wrong password");
        //    }

        //    string token = _service.CreateToken(employee);

        //    return Ok(token);
        //}


    }
}
