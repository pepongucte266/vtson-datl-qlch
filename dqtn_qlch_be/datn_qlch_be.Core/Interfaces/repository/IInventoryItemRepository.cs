using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;

namespace datn_qlch_be.Core.Interfaces.repository
{
    public interface IInventoryItemRepository: IBaseRepository<InventoryItem>
    {
        IEnumerable<InventoryItem[]> GetAllInventoryItem();

        InventoryItem GetInventoryItemByID(string id);

        object GetInventoryItemPaging(PaggingParams paggingParams);

        int InsertInventoryItem(InventoryItem item);
    }
}
