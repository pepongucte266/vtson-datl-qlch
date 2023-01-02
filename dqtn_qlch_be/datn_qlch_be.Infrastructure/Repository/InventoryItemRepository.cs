using Dapper;
using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Infrastructure.Repository
{
    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        #region Constructor
        public InventoryItemRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<InventoryItem[]> GetAllInventoryItem()
        {
            var result = SqlConnection.Query<InventoryItem[]>("Proc_GetAllInventoryItem", commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public InventoryItem GetInventoryItemByID(string id)
        {
            DynamicParameters parameters = new();
            parameters.Add($"$id", id);
            var result = SqlConnection.QueryMultiple("Proc_GetInventoryItemByID", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            var inventoryItem = result.ReadFirst<InventoryItem>();
            inventoryItem.UnitConverts = result.Read<UnitConvert>().ToArray();
            return inventoryItem;
        }

        public object GetInventoryItemPaging(PaggingParams paggingParams)
        {
            DynamicParameters parameters = new();
            parameters.Add($"$Where", paggingParams.Where);
            parameters.Add($"$Sort", paggingParams.Sort);
            parameters.Add($"$PageIndex", paggingParams.PageIndex);
            parameters.Add($"$PageSize", paggingParams.PageSize);
            var result = SqlConnection.QueryMultiple("Proc_GetInventoryItemPagging", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            var inventoryItems = result.Read<InventoryItem>().ToArray();
            var dataPagging = result.ReadFirst<DataPagging>();
            return new { Data = inventoryItems, TotalPage = dataPagging.TotalPage, TotalRecord = dataPagging.TotalRecord };
        }

        public int InsertInventoryItem(InventoryItem item)
        {
            DynamicParameters parameters1 = new();
            DynamicParameters parameters2 = new();
            parameters1.Add($"$InventoryItemName", item.InventoryItemName);
            parameters1.Add($"$InventoryItemType", item.InventoryItemType);
            parameters1.Add($"$InventoryItemCode", item.InventoryItemCode);
            parameters1.Add($"$InventoryItemPrice", item.InventoryItemPrice);
            parameters1.Add($"$Status", item.Status);
            parameters1.Add($"$InventoryItemImage", item.InventoryItemImage);
            parameters1.Add($"$InventoryItemCategoryID", item.InventoryItemCategoryID);
            parameters1.Add($"$Quantity", item.Quantity);
            var id = Guid.NewGuid();
            parameters1.Add($"$InventoryItemID", id);
            parameters2.Add($"$InventoryItemID", id);
            parameters2.Add($"$UnitConvertPrice", item.UnitConvertPrice);
            parameters2.Add($"$InventoryItemUnitID", item.InventoryItemUnitID);
            SqlConnection.Open();
            using (var trans = SqlConnection.BeginTransaction())
            {
            
                SqlConnection.Execute("Proc_InsertInventoryItem", param: parameters1, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                SqlConnection.Execute("Proc_InsertUnitConvert", param: parameters2, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                trans.Commit();
                return 1;
            }
            //var result = SqlConnection.Execute("Proc_InsertInventoryItem", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            
        }

        #endregion
    }
}
