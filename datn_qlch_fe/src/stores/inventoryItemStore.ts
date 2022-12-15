import { defineStore } from "pinia";
import type IInventoryItem from "@/interface/IInventoryItem";
import axios from "axios";
import CONFIG from "@/common/config";
export const useInventoryItemStore = defineStore("inventoryItem", {
  state: () => ({
    inventoryItemList: [] as IInventoryItem[],
    /**
     *Mô tả: /Danh sách hh đang bán
     *created by: VTSON 15-12-15
     */
    inventoryItemOnSale: [] as IInventoryItem[],
  }),
  getters: {
    inventoryItemListLength: (state) => {
      return state.inventoryItemList.length;
    },
    getInventoryItemByID: (state) => {
      return (inventoryItemID: string) =>
        state.inventoryItemList.find(
          (item) => item.InventoryItemID == inventoryItemID
        );
    },
  },
  actions: {
    /**
     *Mô tả: Hàm lấy danh sách hh từ server
     *created by: VTSON 14-12-14
     */
    async getInventoryItemList() {
      let url = CONFIG.BaseURL + "InventoryItem";
      await axios
        .get(url)
        .then((response) => {
          if (response && response.data) {
            this.inventoryItemList = response.data;
          } else {
            this.inventoryItemList = [];
          }
        })
        .catch(() => {
          console.log("Có lỗi xảy ra");
        });
    },

    async getInventoryItemListPaging(
      page: number,
      pageSize: number
    ): Promise<IInventoryItem[]> {
      let start = page == 1 ? 0 : pageSize * (page - 1);
      let end = pageSize * page;

      var result = [];
      while (start < end) {
        result.push(this.inventoryItemList[start]);
        start++;
      }
      return result;
    },
  },
});
