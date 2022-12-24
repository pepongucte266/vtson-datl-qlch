import type IInvoice from "@/interface/IInvoice";
import type IInvoiceDetail from "@/interface/IInvoiceDetail";
import { defineStore } from "pinia";
import Commonfunction from "@/common/commonfunction";
import InventoryItemService from "@/services/InventoryItemService";
export const useInvoiceStore = defineStore("invoice", {
  state: () => ({
    invoiceList: [] as IInvoice[],
    curentInvoiceNo: "HD00001",
  }),
  getters: {
    curentInvoiceDetails: (state) => {
      return state.invoiceList.find(
        (item) => item.InvoiceNo == state.curentInvoiceNo
      )?.InvoiceDetails;
    },
    currentInvoice: (state) => {
      return state.invoiceList.find(item => item.InvoiceNo == state.curentInvoiceNo)
    }
  },
  actions: {
    /**
    *Mô tả: Hàm thêm hh vào hóa đơn
    *created by: VTSON 21-12-21
    */
    async addInventoryItemToInvoice(
      invoiceNo: string,
      invoiceDetail: IInvoiceDetail
    ) {
      var invoice = this.invoiceList.find(
        (invoice) => invoice.InvoiceNo === invoiceNo
      );
      var a = await InventoryItemService.getInventoryItemByID(invoiceDetail.InventoryItemID);
      if (invoice) {
        if(invoice.InvoiceDetails) {
          var index = invoice.InvoiceDetails.findIndex(item => item.InventoryItemID == invoiceDetail.InventoryItemID)
          if(index >= 0) {
            invoice.InvoiceDetails[index].Quantity += invoiceDetail.Quantity
            invoice.InvoiceDetails[index].Amount = invoice.InvoiceDetails[index].InventoryItemPrice * invoice.InvoiceDetails[index].Quantity
          } else {
            invoice.InvoiceDetails.push(invoiceDetail);
          }
        }
        await this.caculateInvoiceAmount(invoice);
      }
    },
    /**
    *Mô tả: Hàm xóa hàng hóa khỏi hóa đơn
    *@param : 
    *created by: VTSON 21-12-21
    */
    async removeInventoryItemInInvoice(invoiceNo: string, inventoryItemID: string) {
      var index = this.invoiceList.findIndex(item => item.InvoiceNo == invoiceNo);
      if(index >=0) {
        this.invoiceList[index].InvoiceDetails = this.invoiceList[index].InvoiceDetails.filter(item => item.InventoryItemID != inventoryItemID);
        var invoice = await this.getInvoiceByInvoiceNo(invoiceNo);
        if(invoice) {
          await this.caculateInvoiceAmount(invoice);
        }
      }
    },

    async updateInventoryItemInInvoice(invoiceNo: string, invoiceDetail:IInvoiceDetail) {
      var invoice = this.invoiceList.find(
        (invoice) => invoice.InvoiceNo === invoiceNo
      );
      if (invoice && invoice.InvoiceDetails) {
        invoice.InvoiceDetails.forEach(item => {
          if(item.InventoryItemID == invoiceDetail.InventoryItemID) {
            item = invoiceDetail
          }
        })
        await this.caculateInvoiceAmount(invoice);
      }
    }
    ,
    /**
     *Mô tả: Hàm tạo hóa đơn mới
     *created by: VTSON 16-12-16
     */
    async createNewInvoice() {
      var invoice: IInvoice = {
        InvoiceNo: "HD00001",
        InvoiceID: "",
        InvoiceType: 1,
        InvoiceDetails: [],
        Amount: 0,
        IsCOD: false,
        CODAmount: 0,
        PromotionID: "",
        DiscountAmount: 0,
        DepositAmount: 0,
      };
      this.invoiceList.push(invoice);
    },

    /**
    *Mô tả: Hàm lấy hóa đơn theo số hóa đơn
    *created by: VTSON 21-12-21
    */
    async getInvoiceByInvoiceNo(
      invoiceNo: string
    ): Promise<IInvoice | undefined> {
      var invoice: IInvoice = this.invoiceList.find(
        (item) => item.InvoiceNo == invoiceNo
      )!;
      return invoice;
    },
    async caculateInvoiceAmount(invoice: IInvoice): Promise<void>{
      if(invoice && invoice.InvoiceDetails) {
        invoice.Amount = invoice.InvoiceDetails.reduce((total,invoiceDetail) => {
          total += invoiceDetail.Amount
          return total;
        },0)
      }
    }
  },
});
