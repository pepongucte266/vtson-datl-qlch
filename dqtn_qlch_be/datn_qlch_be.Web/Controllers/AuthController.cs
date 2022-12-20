using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.services;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> a2420c4b2b22e57a2d91072034b6f0c119899d7b
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> a2420c4b2b22e57a2d91072034b6f0c119899d7b
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


<<<<<<< HEAD
        [HttpPost("register"), Authorize(Roles = "Quản trị hệ thống")]
=======
        [HttpPost("register")]
>>>>>>> a2420c4b2b22e57a2d91072034b6f0c119899d7b
        public async Task<ActionResult<Employee>> RegisterEmployee(EmployeeDto request)
        {

            Employee employee = _service.RegisterEmployee(request);
<<<<<<< HEAD
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
=======
            
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

>>>>>>> a2420c4b2b22e57a2d91072034b6f0c119899d7b

    }
}
