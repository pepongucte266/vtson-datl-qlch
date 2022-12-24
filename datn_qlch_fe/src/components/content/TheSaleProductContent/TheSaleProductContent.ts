import { defineComponent, ref, reactive, computed } from "vue";
import {
  useInventoryItemStore,
  useInvoiceStore,
  useInvoiceDetailStore,
} from "@/stores";
import { storeToRefs } from "pinia";
import type IInventoryItem from "@/interface/IInventoryItem";
import type IInvoiceDetail from "@/interface/IInvoiceDetail";
import { mdiHeart } from "@mdi/js";
import Commonfunction from "@/common/commonfunction";
export default defineComponent({
  setup() {
    const inventoryItemStore = useInventoryItemStore();
    const invoiceStore = useInvoiceStore();
    const invoiceDetailStore = useInvoiceDetailStore();
    var onboarding = ref(0);
    var dataPaging: IInventoryItem[][] = reactive([]);
    var { curentInvoiceDetails } = storeToRefs(invoiceStore);
    //Lấy danh sách hh
    async function loadData() {
      await inventoryItemStore.getInventoryItemList();
      for (let i = 1; i <= 10; i++) {
        dataPaging.push(
          await inventoryItemStore.getInventoryItemListPaging(i, 10)
        );
      }
      await invoiceStore.createNewInvoice();
    }

    async function addInventoryItemToInvoice(inventoryItem: IInventoryItem) {
      // var invoiceDetail = inventoryItem as unknown as IInvoiceDetail;
      var invoiceDetail = Commonfunction.cloneData<IInvoiceDetail>(inventoryItem);
      invoiceDetail.Quantity = 1;
      invoiceDetail.Amount = invoiceDetail.Quantity * invoiceDetail.InventoryItemPrice;
      await invoiceStore.addInventoryItemToInvoice(
        invoiceStore.curentInvoiceNo,
        invoiceDetail
      );
    }

    async function removeInventoryItemInInvoice(inventoryItem: IInventoryItem) {
      await invoiceStore.removeInventoryItemInInvoice(
        invoiceStore.curentInvoiceNo,
        inventoryItem.InventoryItemID
      );
    }

    async function changeProductQuantity(
      inventoryItem: IInventoryItem,
      quantity: number
    ) {
      var invoiceDetail = inventoryItem as unknown as IInvoiceDetail;
      invoiceDetail.Quantity = Number(quantity);
      invoiceDetail.Amount =
        invoiceDetail.Quantity * invoiceDetail.InventoryItemPrice;
      await invoiceStore.updateInventoryItemInInvoice(
        invoiceStore.curentInvoiceNo,
        invoiceDetail
      );
    }

    function randomImage() {
      return `https://loremflickr.com/320/240?random=${Math.floor(Math.random() * 10)}`
    }

    loadData();
    return {
      inventoryItemStore,
      dataPaging,
      onboarding,
      addInventoryItemToInvoice,
      removeInventoryItemInInvoice,
      changeProductQuantity,
      curentInvoiceDetails,
      randomImage
    };
  },
});
