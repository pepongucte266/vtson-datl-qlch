import axios from "axios";
import CONFIG from "@/common/config";
class InventoryItemService {
  getInventoryItemByID(id: string): InventoryItem {
    var endpoint = 'InventoryItem/'+id;
    return axios.get(CONFIG.BaseURL+endpoint).then(response => response.data);
  }
}

export default new InventoryItemService();
