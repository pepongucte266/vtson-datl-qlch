using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryItemUnitController : QLCHBaseController<InventoryItemUnit>
    {
        #region Fields
        readonly IInventoryItemUnitRepository _repository;
        readonly IInventoryItemUnitService _service;
        #endregion
        public InventoryItemUnitController(IInventoryItemUnitRepository repository, IInventoryItemUnitService service) : base(repository, service)
        {
            _repository = repository;
            _service = service;
        }
    }
}
