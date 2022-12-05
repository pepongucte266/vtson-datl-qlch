using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using Newtonsoft.Json;

namespace datn_qlch_be.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodController : QLCHBaseController<Food>
    {
        #region Fields
        readonly IFoodRepository _repository;
        readonly IFoodService _service;
        #endregion

        #region Constructor
        public FoodController(IFoodRepository repository, IFoodService service) : base(repository, service)
        {
            _repository = repository;
            _service = service;
        }
        #endregion


        #region Methods

        ///// <summary>
        ///// Thêm món ăn và sở thích vụ vụ
        ///// </summary>
        ///// Created By: VTSON (24/07/2022)
        //[HttpPost("full")]
        //public IActionResult Insert(Food food, [FromQuery] string foodFavoriteList)
        //{
        //    FoodFavoriteService[] foodFavoriteServices = JsonConvert.DeserializeObject<FoodFavoriteService[]>(foodFavoriteList);
        //    return Ok(_service.InsertFull(food, foodFavoriteServices));
        //}

        ///// <summary>
        ///// Cập nhật món ăn và sở thích phục vụ
        ///// </summary>
        ///// Created By: VTSON (24/07/2022)
        //[HttpPut("full")]
        //public IActionResult Update(Food food, [FromQuery] string foodFavoriteList)
        //{
        //    FoodFavoriteService[] foodFavoriteServices = JsonConvert.DeserializeObject<FoodFavoriteService[]>(foodFavoriteList);
        //    return Ok(_service.UpdateFull(food, foodFavoriteServices));
        //}
        ///// <summary>
        ///// Lấy thông tin món ăn theo id
        ///// </summary>
        ///// Created By: VTSON (14/07/2022)
        //[HttpGet("{id}")]
        //public IActionResult GetById(Guid id)
        //{
        //    try
        //    {
        //        return Ok(_repository.GetById(id));
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}

        ///// <summary>
        ///// Lấy thông tin món ăn theo mã món
        ///// </summary>
        ///// Created By: VTSON (23/07/2022)
        //[HttpGet("search/{foodCode}")]
        //public IActionResult GetByCode(string foodCode)
        //{
        //    try
        //    {
        //        return Ok(_repository.GetByFoodCode(foodCode));
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}

        ///// <summary>
        ///// lấy danh sách món ăn theo filter
        ///// </summary>
        ///// Created By: VTSON (17/07/2022)
        //[HttpGet("Filter")]
        //public IActionResult Filter(int? pageNumber, int? pageSise, string? where, string? sort)
        //{
        //    var res = _service.GetFilter(pageNumber, pageSise, where, sort);
        //    return Ok(res);
        //}
        #endregion

    }
}
