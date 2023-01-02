import axios from "axios";
import CONFIG from "@/common/config";
import type IInventoryItemUnit from "@/interface/IInventoryItemUnit";

class InventoryItemUnitService {
  async getall(): Promise<IInventoryItemUnit[]> {
    var endpoint = "InventoryItemUnit";
    const response = await axios.get(CONFIG.BaseURL + endpoint);
    return response.data;
  }
}

export default new InventoryItemUnitService();
