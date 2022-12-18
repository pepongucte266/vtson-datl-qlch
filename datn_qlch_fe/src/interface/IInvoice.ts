import type IInvoiceDetail from "./IInvoiceDetail";

export default interface IInvoice {
  InvoiceID: string;
  InvoiceNo: string;
  InvoiceType: number;
  Amount: number;
  IsCOD: boolean;
  CODAmount: number;
  PromotionID: string;
  DiscountAmount: number;
  DepositAmount: number;
  EmployeeID?:string;
  InvoiceDetails: IInvoiceDetail[];
}
