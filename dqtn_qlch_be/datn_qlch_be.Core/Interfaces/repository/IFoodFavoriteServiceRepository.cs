using datn_qlch_be.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.repository
{
    public interface IFoodFavoriteServiceRepository : IBaseRepository<FoodFavoriteService>
    {
        /// <summary>
        /// Lấy danh sách sở thích phục vụ theo id món ăn
        /// </summary>
        /// <param name="id">Id của món ăn</param>
        /// CreateBy: VTSON 23/07/2022
        IEnumerable<FoodFavoriteService> GetById(Guid id);
    }
}
