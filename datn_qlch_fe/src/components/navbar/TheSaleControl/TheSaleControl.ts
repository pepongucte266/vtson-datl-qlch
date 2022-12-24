import { defineComponent } from "vue";
import { mdiAccountCircleOutline } from "@mdi/js";

import { useInvoiceStore } from "@/stores";
import { storeToRefs } from "pinia";

export default defineComponent({
  setup() {
    const invoiceStore = useInvoiceStore();
    var a = 1;
    var { currentInvoice } = storeToRefs(invoiceStore);
    async function loadData() {

    }
    return {
      a,
      mdiAccountCircleOutline,
      invoiceStore,
      currentInvoice
    };
  },
});
