import {defineComponent,defineAsyncComponent , ref,reactive} from 'vue'
import { useInventoryItemStore } from '@/stores'
import type IInventoryItem from '@/interface/IInventoryItem'
export default defineComponent({
  setup() {
    const inventoryItemStore = useInventoryItemStore()
    var onboarding = ref(0)
    var dataPaging : IInventoryItem[][] = reactive([])
    //Lấy danh sách hh 
    
    
    async function loadData() {
      await inventoryItemStore.getInventoryItemList()
      for (let i = 1; i <=10; i++) {
        dataPaging.push(await inventoryItemStore.getInventoryItemListPaging(i,10))
      }
    }

    async function addInventoryItemToInvoice(inventoryItem: IInventoryItem) {
      console.log('inventoryItem: ', inventoryItem.InventoryItemName);
      
    }
    loadData()
    return {
      inventoryItemStore,
      dataPaging,
      onboarding,
      addInventoryItemToInvoice
    }
  }
})
