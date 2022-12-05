import { mdiAccount, mdiApps} from "@mdi/js";
import { defineComponent, toRefs, reactive } from 'vue'
import TheHeaderMenu  from "../TheHeaderMenu/TheHeaderMenu.vue";
export default defineComponent({
  components: {
    TheHeaderMenu
  },
  setup() {
    const variables = reactive({
      showPopupHeaderMenu: false
    })
    return {
      ...toRefs(variables),
      mdiAccount,
      mdiApps
    }
  }
})
