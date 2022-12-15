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
}
