using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QLCHBaseController<Entity> : ControllerBase
    {
        #region Fields
        IBaseRepository<Entity> _repository;
        IBaseService<Entity> _service;
        #endregion

        #region Constructor
        public QLCHBaseController(IBaseRepository<Entity> repository, IBaseService<Entity> service)
        {
            _repository = repository;
            _service = service;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// Created By: VTSON (15/07/2022)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        /// <summary>
        /// Thêm mới bản ghi vào database
        /// </summary>
        /// Created By: VTSON (17/07/2022)
        [HttpPost]
        public IActionResult Post(Entity entity)
        {
            return Ok(_service.InsertService(entity));
        }

        /// <summary>
        /// Xóa các bản ghi theo id
        /// </summary>
        /// Created By: VTSON (17/07/2022)
        [HttpDelete("{ids}")]
        public IActionResult Delete(string ids)
        {
            return Ok(_repository.Delete(ids));
        }

        /// <summary>
        /// Cập nhật bản ghi theo id
        /// </summary>
        /// Created By: VTSON (18/07/2022)
        [HttpPut("{id}")]
        public IActionResult Put(Entity entity)
        {
            return Ok(_service.UpdateService(entity));
        }
        #endregion

    }
}
