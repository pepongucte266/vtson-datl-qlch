import {defineComponent, ref, reactive, computed} from 'vue'
import { useInventoryItemStore, useInvoiceStore, useInvoiceDetailStore } from '@/stores'
import { storeToRefs } from 'pinia'
import type IInventoryItem from '@/interface/IInventoryItem'
import type IInvoiceDetail from '@/interface/IInvoiceDetail'
export default defineComponent({
  setup() {
    const inventoryItemStore = useInventoryItemStore()
    const invoiceStore = useInvoiceStore()
    const invoiceDetailStore = useInvoiceDetailStore()
    var onboarding = ref(0)
    var dataPaging : IInventoryItem[][] = reactive([])
    var {curentInvoiceDetail} = storeToRefs(invoiceStore)
    //Lấy danh sách hh 
    async function loadData() {
      await inventoryItemStore.getInventoryItemList()
      for (let i = 1; i <=10; i++) {
        dataPaging.push(await inventoryItemStore.getInventoryItemListPaging(i,10))
      }
      await invoiceStore.createNewInvoice()
    }

    async function addInventoryItemToInvoice(inventoryItem: IInventoryItem) {
      var invoiceDetail = inventoryItem as unknown as IInvoiceDetail
      invoiceDetail.Quantity = 0
      invoiceDetail.UnitPrice = 0
      invoiceDetail.Price = 0
      await invoiceStore.addInventoryItemToInvoice(invoiceStore.curentInvoiceNo, invoiceDetail)
      
    }

    async function removeInventoryItemInInvoice(inventoryItem: IInventoryItem) {
      
    }
    
    loadData()
    return {
      inventoryItemStore,
      dataPaging,
      onboarding,
      addInventoryItemToInvoice,
      curentInvoiceDetail,
    }
  }
})
