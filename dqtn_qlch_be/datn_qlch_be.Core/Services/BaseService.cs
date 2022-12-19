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
    public class BaseService<Entity> : IBaseService<Entity>
    {
        #region Fields
        protected IBaseRepository<Entity> Repository;
        protected List<string> ErrorMessages;
        #endregion

        
        #region Constructor
        public BaseService(IBaseRepository<Entity> repository)
        {
            Repository = repository;
            ErrorMessages = new List<string>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// service thêm mới đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        /// Created By: VTSON (20/07/2022)
        public int InsertService(Entity entity)
        {

            bool isValid = Validate(Enum.ValidateMode.Insert, entity);
            if (isValid)
            {
                var res = Repository.Insert(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(Resources.ResourceVN.VN_HaveAnErrorOccurred, ErrorMessages);
            }


        }

        /// <summary>
        /// service cập nhật dố tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        /// Created By: VTSON (20/07/2022)
        public int UpdateService(Entity entity)
        {
            var isValid = Validate(Enum.ValidateMode.Update, entity);
            if (isValid)
            {
                var res = Repository.Update(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(Resources.ResourceVN.VN_HaveAnErrorOccurred, ErrorMessages);
            }
        }

        /// <summary>
        /// Hàm kiểm tra dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>true: dữ liệu hợp lệ; false: dữ liệu không hợp lệ</returns>
        /// Created By: VTSON (20/07/2022)
        protected virtual bool Validate(Enum.ValidateMode mode, Entity entity) => true;
        #endregion

    }
}
