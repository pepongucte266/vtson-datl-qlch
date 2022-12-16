import type IInvoice from "@/interface/IInvoice";
import type IInvoiceDetail from "@/interface/IInvoiceDetail";
import { defineStore } from "pinia";
import { useInvoiceStore } from '@/stores'
export const useInvoiceDetailStore = defineStore("invoiceDetail", {
  state: () => ({ 
    invoiceDetailList: [] as IInvoiceDetail[], 
  }),
  getters: {
    
  }
  ,
  actions: {
    async getInvoiceDetailsByInvoiceNo(invoiceNo: string) {
      const invoiceStore = useInvoiceStore()
      var invoice = await invoiceStore.getInvoiceByInvoiceNo(invoiceNo)
      if(invoice && invoice.InvoiceDetails) {
        return invoice.InvoiceDetails
      }
    }
  }
  
})
