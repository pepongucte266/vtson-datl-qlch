import type IInvoice from "@/interface/IInvoice";
import { defineStore } from "pinia";
export const invoiceStore = defineStore("invoice", {
  state: () => ({ 
    invoiceList: [] as IInvoice[], 
    curentInvoice : {} as IInvoice
  }),
  actions: {}
  
})
