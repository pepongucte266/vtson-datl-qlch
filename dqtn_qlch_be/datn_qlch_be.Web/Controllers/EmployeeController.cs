using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : QLCHBaseController<Employee>
    {
        #region Fields
        readonly IEmployeeRepository _repository;
        readonly IEmployeeService _service;
        #endregion


        public EmployeeController(IEmployeeRepository repository, IEmployeeService service) : base (repository, service)
        {
            _repository = repository;
            _service = service;
        }
        


    }
}
