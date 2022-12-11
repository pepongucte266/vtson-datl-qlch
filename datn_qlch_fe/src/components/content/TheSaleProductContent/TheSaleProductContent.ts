import {defineComponent, ref,reactive} from 'vue'
export default defineComponent({
  setup(props) {
    var items = reactive([
      {
        InventoryItemCode: 'CO',
        InventoryItemName: 'coca',
        Price: 100000,
        UnitPrice:'lon',
        Quantity: 2
      },
      {
        InventoryItemCode: 'PS',
        InventoryItemName: 'pepsi',
        Price: 100000,
        UnitPrice:'lon',
        Quantity: 1
      },
      {
        InventoryItemCode: 'FA',
        InventoryItemName: 'fanta',
        Price: 100000,
        UnitPrice:'lon',
        Quantity: 1
      }
    ])
    var onboarding = ref(0)
    return {
      items,
      onboarding
    }
  }
})
