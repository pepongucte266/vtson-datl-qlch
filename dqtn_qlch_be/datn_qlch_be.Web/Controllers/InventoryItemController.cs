using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : QLCHBaseController<InventoryItem>
    {
        #region Fields
        readonly IInventoryItemRepository _repository;
        readonly IInventoryItemService _service;
        #endregion

        #region Constructor
        public InventoryItemController(IInventoryItemRepository repository, IInventoryItemService service) : base(repository, service)
        {
            _repository = repository;
            _service = service;
        }
        #endregion
    }
}
