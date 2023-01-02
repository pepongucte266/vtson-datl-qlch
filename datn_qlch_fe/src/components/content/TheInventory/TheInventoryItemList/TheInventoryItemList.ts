import { defineComponent, reactive, toRefs, ref, nextTick } from "vue";
import { mdiArchivePlusOutline, mdiDelete, mdiNoteEdit } from "@mdi/js";
import { useInventoryItemStore } from "@/stores";
import InventoryItemService from "@/services/InventoryItemService";
import TheInventoryItemDetail from "@/components/content/TheInventory/TheInventoryItemDetail/TheInventoryItemDetail.vue"
import type IInventoryItem from "@/interface/IInventoryItem";
import QLCHDialog from '@/components/base/QLCHDialog/QLCHDialog.vue'
import * as Enum from "@/common/enum"
export default defineComponent({
  components: {
    TheInventoryItemDetail,
    QLCHDialog
  },
  setup() {
    const inventoryItemStore = useInventoryItemStore();
    var state = reactive({
      inventoryItems: [] as IInventoryItem[],
      totalPage: 0,
      showDialog: false,
      dialogMessage: '',
      dialogTitle: 'Cảnh báo',
      showInventoryItemDetail: false,
      action: Enum.Action.Insert,
      toastBox: false,
      toastColor: 'success',
      currentInventoryItemID: ''
    });

    /**
    *Mô tả: Ref template cho dialog
    *created by: VTSON 01-01-01
    */
    const qlchDialog = ref<InstanceType<typeof QLCHDialog> | null>()

    async function loadData() {
      var inventoryItemDataPagging =
        await inventoryItemStore.getInventoryItemListPaging(1, 50);
      state.inventoryItems = inventoryItemDataPagging.Data;
      state.totalPage = inventoryItemDataPagging.TotalPage;
    }

    async function deleteInventoryItem(inventoryItem: IInventoryItem) {
      var result = false
      state.dialogMessage = `Bạn có muốn xóa hàng hóa <strong>${inventoryItem.InventoryItemName}</strong> không?`
      state.showDialog = true;
      await nextTick();
      await qlchDialog.value?.getResult().then((dialogResult: boolean) => {
        result = dialogResult
      })
      if(result) {
        await InventoryItemService.DeleteInventoryItemByIds(inventoryItem.InventoryItemID)
        await loadData()
      }
    }

    async function openInventoryItemDetail(action: Enum.Action, inventoryItemID?: string) {
      if(inventoryItemID) {
        state.currentInventoryItemID = inventoryItemID
      }
      state.action = action
      state.showInventoryItemDetail = true;
    }



    loadData();
    return {
      ...toRefs(state),
      mdiArchivePlusOutline,
      mdiDelete,
      mdiNoteEdit,
      deleteInventoryItem,
      Enum,
      qlchDialog,
      openInventoryItemDetail
    };
  },
});
