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
    public class InventoryItemService: BaseService<InventoryItem>, IInventoryItemService
    {
        #region Fields
        readonly IInventoryItemRepository _repository;

        #endregion

        #region Constructor
        public InventoryItemService(IInventoryItemRepository repository) : base(repository)
        {
            _repository = repository;
        }


        #endregion

        public int InsertInventoryItem(InventoryItem item)
        {
            if(Validate(Enum.ValidateMode.Insert, item))
            {
                return _repository.InsertInventoryItem(item);
            }
            else
            {
                throw new MISAValidateException(Resources.ResourceVN.VN_HaveAnErrorOccurred, ErrorMessages);
            }
        }

        protected override bool Validate(Enum.ValidateMode mode, InventoryItem inventoryItem)
        {
            if (inventoryItem == null) return false;
            if (string.IsNullOrEmpty(inventoryItem.InventoryItemName))
            {
                ErrorMessages.Add(Resources.vn.InventoryItemResource.InventoryItemNameIsRequire);
            }
            if (string.IsNullOrEmpty(inventoryItem.InventoryItemCode))
            {
                ErrorMessages.Add(Resources.vn.InventoryItemResource.InventoryItemCodeIsRequire);
            }
            if(inventoryItem.InventoryItemUnitID == Guid.Empty)
            {
                ErrorMessages.Add(Resources.vn.InventoryItemResource.UnitConvertIDIsRequire);
            }
            if (mode == Enum.ValidateMode.Insert && Repository.IsExistByValue("InventoryItemCode", inventoryItem.InventoryItemCode!))
            {
                ErrorMessages.Add(Resources.vn.InventoryItemResource.InventoryItemCodeIsExisted);
            }
            return ErrorMessages.Count <= 0;
        }
    }
}
