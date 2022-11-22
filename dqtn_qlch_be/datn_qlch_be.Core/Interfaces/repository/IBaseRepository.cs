using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.repository
{
    public interface IBaseRepository<Entity>
    {
        /// <summary>
        /// Lấy tất cả
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Created By: VTSON (19/07/2022) 
        IEnumerable<Entity> GetAll();

        /// <summary>
        /// Thên mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        int Insert(Entity entity);

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        int Update(Entity entity);

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi xóa thành côngg</returns>
        /// Created By: VTSON (19/07/2022) 
        int Delete(string ids);


        /// <summary>
        /// Kiểm tra entity đã tồn tại
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="curentId"></param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// Created By: VTSON (19/07/2022) 
        bool IsExistByValue(string column, Guid? curentId, string value);

    }
}
