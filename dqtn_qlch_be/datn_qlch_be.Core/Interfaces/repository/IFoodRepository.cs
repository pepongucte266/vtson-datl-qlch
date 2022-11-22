using datn_qlch_be.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.repository
{
    public interface IFoodRepository : IBaseRepository<Food>
    {

        /// <summary>
        /// Lấy thông tin món ăn theo id
        /// </summary>
        /// <param name="id">Id của món ăn</param>
        /// <returns>food:thông tin món ăn</returns>
        /// CreateBy: VTSON 22/07/2022
        Food GetById(Guid id);

        /// <summary>
        /// Lấy thông tin món ăn theo mã món
        /// </summary>
        /// <param name="foodCode">mã món ănn</param>
        /// <returns>food:thông tin món ăn</returns>
        /// CreateBy: VTSON 23/07/2022
        Food GetByFoodCode(string foodCode);

        /// <summary>
        /// Lấy danh sách món ăn
        /// </summary>
        /// <param name="pageSize">Số bản ghi</param>
        /// <param name="pageNumber">Trang số</param>
        /// <returns>totalRecord: Tổng số bản ghi; totalPage: Tổng số trang; Data: danh sách nhân viên</returns>
        /// CreateBy: VTSON 22/07/2022
        object GetFilter(int? pageNumber, int? pageSise, string? where, string? sort);

        /// <summary>
        /// Thêm mới vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        int InsertFull(Food food, FoodFavoriteService[] foodFavoriteServices);

        /// <summary>
        /// cập nhật vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        int UpdateFull(Food food, FoodFavoriteService[] foodFavoriteServices);
    }
}
