using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using datn_qlch_be.Core.DTOs;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet("{id}")]
        public IActionResult GetInventoryItemById(string id)
        {
            return Ok(_repository.GetInventoryItemByID(id));
        }

        [HttpPost("pagging")]
        public IActionResult GetInventoryItemPagging(PaggingParams param)
        {
            return Ok(_repository.GetInventoryItemPaging(param));
        }

        [HttpPost("insert")]
        public IActionResult InsertInventoryItem(InventoryItem item)
        {
            return Ok(_service.InsertInventoryItem(item));
        }
    }
}
