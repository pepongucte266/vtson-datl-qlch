using datn_qlch_be.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.services
{
    public interface IFoodService : IBaseService<Food>
    {
        /// <summary>
        /// Lấy danh sách món ăn theo filter
        /// </summary>
        /// <param name="pageSize">Số bản ghi</param>
        /// <param name="pageNumber">Trang số</param>
        /// <param name="where">câu truy vấn</param>
        /// <param name="sort"></param>
        /// <returns>TotalRecord: Tổng số bản ghi; TotalPage: Tổng số trang; Data: danh sách món ăn</returns>
        /// Created By: VTSON (22/07/2022) 
        //object GetFilter(int? pageNumber, int? pageSise, string? where, string? sort);

        ///// <summary>
        ///// Thêm mới vào db
        ///// <param name="food">món ăn</param>
        ///// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        ///// </summary>
        ///// CreateBy: VTSON 25/07/2022
        //int InsertFull(Food food, FoodFavoriteService[] foodFavoriteServices);
        ///// <summary>
        ///// Cập nhật vào db
        ///// <param name="food"> món ăn</param>
        ///// <param name="foodFavoriteServices"> các sơ thích phục vụ</param>
        ///// </summary>
        ///// CreateBy: VTSON 25/07/2022
        //int UpdateFull(Food food, FoodFavoriteService[] foodFavoriteServices);
    }
}
