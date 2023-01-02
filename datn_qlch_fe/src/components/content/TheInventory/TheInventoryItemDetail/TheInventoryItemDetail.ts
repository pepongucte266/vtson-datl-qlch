import { defineComponent, reactive, toRefs, computed } from "vue";
import type { PropType } from 'vue'
import InventoryItemUnitService from "@/services/InventoryItemUnitService";
import InventoryItemService from "@/services/InventoryItemService";
import type IInventoryItemUnit from "@/interface/IInventoryItemUnit";
import type IInventoryItem from "@/interface/IInventoryItem";
import * as Enum from "@/common/enum"
import { useCommonStore } from "@/stores";
export default defineComponent({
  props: {
    showInventoryItemDetail: Boolean,
    inventoryItemID: String,
    action: {
      type: Number as PropType<Enum.Action>,
      required: true,
    },
  },
  setup(props, {emit}) {
    const commonStore = useCommonStore()
    const state = reactive({
      testtttt: false,
      dialog: true,
      desserts: [
        {
          name: 'Đôi',
          calories: 2,
        },
        {
          name: 'Chục',
          calories: 10,
        }
      ],
      inventoryItemUnits: [] as IInventoryItemUnit[],
      inventoryItem: {
        InventoryItemName: '',
        InventoryItemCode: '',
        InventoryItemPrice: 0,
        Quantity: 0,
        InventoryItemImage: '',
        Description: '',
        InventoryItemUnitID: ''
      } as IInventoryItem,
    })

    var show: any = computed<boolean>({
      get() {
        return props.showInventoryItemDetail
      },
      set(value: boolean) {
        emit('change', value);
      }
    })

    async function loadData() {
      commonStore.showLoading();
      state.inventoryItemUnits = await InventoryItemUnitService.getall()
      if(props.action == Enum.Action.Edit && props.inventoryItemID) {
        state.inventoryItem = await InventoryItemService.getInventoryItemByID(props.inventoryItemID)
      }
      commonStore.hideLoading();
    }

    async function insertInventoryItem() {
      var result = await InventoryItemService.InsertInventoryItem(state.inventoryItem)
      console.log(result);
      
    }

    async function updateInventoryItem() {

    }

    async function handlerSaveBtn() {
      if(props.action == Enum.Action.Insert) {
        await insertInventoryItem()
      } else if(props.action == Enum.Action.Edit) {
        await updateInventoryItem()
      }
      show.value = false
    }

    loadData()
    return {...toRefs(state), show, handlerSaveBtn}
  }

})
