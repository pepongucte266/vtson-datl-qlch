import type IInvoice from "@/interface/IInvoice";
import type IInvoiceDetail from "@/interface/IInvoiceDetail";
import { defineStore } from "pinia";
export const useInvoiceStore = defineStore("invoice", {
  state: () => ({ 
    invoiceList: [] as IInvoice[], 
    curentInvoiceNo : 'HD00001'
  }),
  getters: {
    curentInvoiceDetail: (state) => {
      return state.invoiceList.find(item => item.InvoiceNo == state.curentInvoiceNo)?.InvoiceDetails
    }
  }
  ,
  actions: {
    async addInventoryItemToInvoice(invoiceNo: string, invoiceDetail: IInvoiceDetail) {
      var invoice = this.invoiceList.find(invoice => invoice.InvoiceNo === invoiceNo);
      if(invoice) {
        invoice.InvoiceDetails.push(invoiceDetail);
      }
    },
    /**
    *Mô tả: Hàm tạo hóa đơn mới
    *created by: VTSON 16-12-16
    */
    async createNewInvoice() {
      var invoice: IInvoice = {
        InvoiceNo: 'HD00001',
        InvoiceID: '',
        InvoiceType: 1,
        InvoiceDetails: [],
        Amount: 0,
        IsCOD: false,
        CODAmount: 0,
        PromotionID: '',
        DiscountAmount: 0,
        DepositAmount: 0
      }
      this.invoiceList.push(invoice)
    },

    async getInvoiceByInvoiceNo(invoiceNo: string): Promise<IInvoice | undefined> {
      var invoice: IInvoice = this.invoiceList.find(item => item.InvoiceNo == invoiceNo)!
      return invoice
    }

  }
  
})
