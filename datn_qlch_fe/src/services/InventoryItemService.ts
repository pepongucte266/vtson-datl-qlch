import axios from "axios";
import CONFIG from "@/common/config";
import * as Enum from "@/common/enum"
import type IInventoryItem from "@/interface/IInventoryItem";
import type IResultPagging from "@/interface/IResultPagging";
import type IUnitConvert from "@/interface/IUnitConvert";

class InventoryItemService {
  async getInventoryItemByID(id: string): Promise<IInventoryItem> {
    var endpoint = "InventoryItem/" + id;
    const response = await axios.get(CONFIG.BaseURL + endpoint);
    if(response && response.data && response.data.UnitConverts) {
      response.data.InventoryItemUnitID = response.data.UnitConverts.find((unit: IUnitConvert) => unit.UnitConvertType == Enum.UnitConvertType.Default)?.InventoryItemUnitID
    }
    return response.data;
  }

  async getInventoryItemPagging(
    pageIndex: number,
    pageSize: number,
    where?: string,
    sort?: string
  ): Promise<IResultPagging<IInventoryItem[]>> {
    var url = CONFIG.BaseURL + CONFIG.Endpoint.InventoryItem.Pagging;
    var params = {
      PageIndex: pageIndex,
      PageSize: pageSize,
      Where: where,
      Sort: sort,
    };
    const response = await axios.post(url, params);
    return response.data;
  }

  async InsertInventoryItem(inventoryItem: IInventoryItem ) {
    var url = CONFIG.BaseURL + CONFIG.Endpoint.InventoryItem.Insert;
    const response = await axios.post(url, inventoryItem);
    return response.data;
  }

  async DeleteInventoryItemByIds(ids: string) {
    var url = CONFIG.BaseURL + 'InventoryItem/'+ ids;
    const response = await axios.delete(url);
    return response.data;
  }
}

export default new InventoryItemService();
