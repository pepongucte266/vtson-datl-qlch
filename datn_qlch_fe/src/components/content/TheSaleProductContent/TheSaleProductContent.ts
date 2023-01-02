import { defineComponent, reactive, toRefs, watch } from "vue";
import {
  useInventoryItemStore,
  useInvoiceStore,
  useInvoiceDetailStore,
  useCommonStore,
} from "@/stores";
import { storeToRefs } from "pinia";
import type IInventoryItem from "@/interface/IInventoryItem";
import type IInvoiceDetail from "@/interface/IInvoiceDetail";
import Commonfunction from "@/common/commonfunction";
export default defineComponent({
  setup() {
    const inventoryItemStore = useInventoryItemStore();
    const invoiceStore = useInvoiceStore();
    const commonStore = useCommonStore();
    const invoiceDetailStore = useInvoiceDetailStore();
    var state = reactive({
      inventoryitems: [] as IInventoryItem[],
      totalPage: 1,
      onboarding: 0,
    });
    var { curentInvoiceDetails } = storeToRefs(invoiceStore);
    //Lấy danh sách hh
    async function loadData() {
      commonStore.showLoading();
      var inventoryItemDataPaging =
        await inventoryItemStore.getInventoryItemListPaging(1, 10);
      state.inventoryitems = inventoryItemDataPaging.Data;
      state.totalPage = inventoryItemDataPaging.TotalPage;
      await invoiceStore.createNewInvoice();
      commonStore.hideLoading();
    }

    async function addInventoryItemToInvoice(inventoryItem: IInventoryItem) {
      // var invoiceDetail = inventoryItem as unknown as IInvoiceDetail;
      var invoiceDetail =
        Commonfunction.cloneData<IInvoiceDetail>(inventoryItem);
      invoiceDetail.Quantity = 1;
      invoiceDetail.Amount =
        invoiceDetail.Quantity * invoiceDetail.InventoryItemPrice;
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

    watch(
      () => state.onboarding,
      async (pageIndex) => {
        commonStore.showLoading();
        var inventoryItemDataPaging =
          await inventoryItemStore.getInventoryItemListPaging(
            pageIndex + 1,
            10
          );
        state.inventoryitems = inventoryItemDataPaging.Data;
        commonStore.hideLoading();
      }
    );

    function randomImage() {
      return `https://loremflickr.com/320/240?random=${Math.floor(
        Math.random() * 10
      )}`;
    }

    loadData();
    return {
      ...toRefs(state),
      inventoryItemStore,
      addInventoryItemToInvoice,
      removeInventoryItemInInvoice,
      changeProductQuantity,
      curentInvoiceDetails,
      randomImage,
    };
  },
});
