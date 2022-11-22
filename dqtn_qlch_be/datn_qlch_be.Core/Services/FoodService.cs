using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Exceptions;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Services
{
    public class FoodService : BaseService<Food>, IFoodService
    {

        #region Fields
        readonly IFoodRepository _repository;

        #endregion

        #region Constructor
        public FoodService(IFoodRepository repository) : base(repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy danh sách món ăn theo filter
        /// </summary>
        /// <param name="pageSize">Số bản ghi</param>
        /// <param name="pageNumber">Trang số</param>
        /// <param name="where">câu truy vấn</param>
        /// <param name="sort"></param>
        /// <returns>TotalRecord: Tổng số bản ghi; TotalPage: Tổng số trang; Data: danh sách món ăn</returns>
        /// Created By: VTSON (22/07/2022) 
        public object GetFilter(int? pageNumber, int? pageSise, string? where, string? sort)
        {
            object res = _repository.GetFilter(pageNumber, pageSise, where, sort);
            IEnumerable<Food>? foods = res.GetType().GetProperty("Data").GetValue(res) as IEnumerable<Food>;
            if (foods.Count() <= 0)
            {
                res = null;
            }
            return res;
        }

        /// <summary>
        /// Thêm mới vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        public int InsertFull(Food food, FoodFavoriteService[] foodFavoriteServices)
        {
            bool isValid = Validate("insert", food);
            
            if (isValid)
            {
                var res = _repository.InsertFull(food, foodFavoriteServices);
                return res;
            }
            else
            {
                throw new MISAValidateException(Resources.ResourceVN.VN_HaveAnErrorOccurred, ErrorMessages);
            }
            
        }

        /// <summary>
        /// Cập nhật vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        public int UpdateFull(Food food, FoodFavoriteService[] foodFavoriteServices)
        {
            bool isValid = Validate("update", food);

            var listCheck = new List<Guid>();
            foreach (FoodFavoriteService item in foodFavoriteServices)
            {
                if(listCheck.Contains((Guid)item.FavoriteServiceId))
                {
                    ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodFavoriteIsDuplicate);
                    throw new MISAValidateException(Resources.ResourceVN.VN_HaveAnErrorOccurred, ErrorMessages);
                } else
                {
                    listCheck.Add((Guid)item.FavoriteServiceId);
                }
            }

            if (isValid)
            {
                var res = _repository.UpdateFull(food, foodFavoriteServices);
                return res;
            }
            else
            {
                throw new MISAValidateException("errors", ErrorMessages);
            }
        }

        protected override bool Validate(string mode, Food food)
        {

            if (food == null) return false;
            if (string.IsNullOrEmpty(food.FoodCode))
            {
                ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodCodeNotEmpty);
            }
            if (string.IsNullOrEmpty(food.FoodName))
            {
                ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodNameNotEmpty);
            }
            if (food.FoodUnitId == null)
            {
                ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodUnitNameNotEmpty);
            }
            if (food.FoodSellPrice == null)
            {
                ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodSellPriceNotEmpty);
            }
            if (food.FoodTax == null)
            {
                ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodTaxNotEmpty);
            }
            if (mode == "insert")
            {
                if (_repository.IsExistByValue("FoodCode", null, food.FoodCode))
                {
                    ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodCodeExitsed);
                }
            }
            else
            {
                if (_repository.IsExistByValue("FoodCode", food.FoodId, food.FoodCode))
                {
                    ErrorMessages.Add(Resources.ResourceVN.VN_ValidateError_FoodCodeExitsed);
                }
            }


            return ErrorMessages.Count > 0 ? false : true;
        }
        #endregion
        
    }
}
