export default interface IInventoryItem {
  InventoryItemID: string;
  InventoryItemName: string;
  InventoryItemCode: string;
  InventoryItemType: string;
  InventoryItemPrice: number;
  Status: number;
  InventoryItemImage?: string;
  Quantity: number;
  UnitPrice: number;
  Price: number;
}
