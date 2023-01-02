using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datn_qlch_be.Core.Entities;

namespace datn_qlch_be.Core.Interfaces.services
{
    public interface IInventoryItemService: IBaseService<InventoryItem>
    {
        int InsertInventoryItem(InventoryItem item);
    }
}
