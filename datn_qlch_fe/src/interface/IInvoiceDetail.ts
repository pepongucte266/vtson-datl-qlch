import type IInventoryItem from "./IInventoryItem";

export default interface IInvoiceDetail extends IInventoryItem{
  InvoiceDetailID: string;
  InventoryItemID: string;
  RefID: string;
  PromotionID: string;
  Quantity: number;
  UnitPrice: number;
  Amount: number;
  DiscountAmount: number;
}
