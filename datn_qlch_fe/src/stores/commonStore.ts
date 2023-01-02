import { defineStore } from "pinia";
export const useCommonStore = defineStore("common", {
  state: () => ({ 
    overlay: false, 
  }),
  actions: {
    showLoading() {
      this.overlay = true;
    },
    hideLoading() {
      this.overlay = false;
    }
  }
  
})
