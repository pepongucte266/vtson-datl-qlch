import { defineStore } from "pinia";
import type IInventoryItem from "@/interface/IInventoryItem";
import axios from "axios";
import CONFIG from "@/common/config";
import InventoryItemService from "@/services/InventoryItemService";
import type IResultPagging from "@/interface/IResultPagging";
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
    ): Promise<IResultPagging<IInventoryItem[]>> {
      var result = await InventoryItemService.getInventoryItemPagging(page, pageSize, "", "");
      return result;
    },
  },
});
