import {defineComponent, ref,computed} from 'vue'
import {  mdiApps} from "@mdi/js";
export default defineComponent({
  props: {
    showPopupHeaderMenu: Boolean
  },
  setup(props,{emit}) {
    //Biến hiển thi popup
    var show = computed<boolean>({
     get() {
      return props.showPopupHeaderMenu;
     },
     set(value) {
      emit('update:showPopupHeaderMenu',value)
     }
    })
    
    const dataMenu = ref([
      {
        name: 'Bán hàng',
        icon: mdiApps,
        link: "/"
      },
      {
        name: 'DS hóa đơn',
        icon: mdiApps,
        link: "/invoices"
      },
      {
        name: 'Báo cáo',
        icon: mdiApps,
        link: "/"
      },
      {
        name: 'Thu chi',
        icon: mdiApps,
        link: "/"
      },
      {
        name: 'Thu chi',
        icon: mdiApps,
        link: "/"
      },
      {
        name: 'Thu chi',
        icon: mdiApps,
        link: "/"
      }
    ])
    return {
      show,
      dataMenu,
      mdiApps
    }
  }
})
