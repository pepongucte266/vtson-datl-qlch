import type * as Enum from "@/common/enum"
export default interface IUnitConvert {
  UnitConvertID: string;
  InventoryItemID: string;
  InventoryItemUnitID: string;
  UnitConvertPrice: number;
  UnitConvertRate: number;
  UnitConvertSaleDefault: number;
  UnitConvertType: Enum.UnitConvertType;
}
