using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;

namespace datn_qlch_be.Web.Controllers
{
    public class FoodFavoriteServiceController : QLCHBaseController<FoodFavoriteService>
    {
        #region Fields

        readonly IFoodFavoriteServiceRepository _repository;
        #endregion

        #region Constructor
        public FoodFavoriteServiceController(IFoodFavoriteServiceRepository repository, IFoodFavoriteServiceService service) : base(repository, service)
        {
            _repository = repository;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Lấy danh sách sở thích phục vụ theo id món ăn
        /// </summary>
        /// Created By: VTSON (23/07/2022)
        #endregion
        [HttpGet("{FoodId}")]
        public IActionResult GetById(Guid FoodId)
        {
            try
            {
                return Ok(_repository.GetById(FoodId));
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
