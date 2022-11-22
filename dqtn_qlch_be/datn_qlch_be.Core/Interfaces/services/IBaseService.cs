using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.services
{
    public interface IBaseService<Entity>
    {
        /// <summary>
        /// Serrvice thêm mới một đối tượng 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created By: VTSON (20/07/2022) 
        int InsertService(Entity entity);

        /// <summary>
        /// Serrvice cập nhật một đối tượng 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created By: VTSON (20/07/2022) 
        int UpdateService(Entity entity);
    }
}
