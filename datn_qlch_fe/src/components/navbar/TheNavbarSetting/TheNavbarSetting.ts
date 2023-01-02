import { defineComponent, reactive, toRefs } from "vue";
import {
  mdiWarehouse,
  mdiAccountCircleOutline,
  mdiCashMultiple,
} from "@mdi/js";

export default defineComponent({
  setup() {
    var items = reactive([
      {
        value: 1,
        title: "Hàng hóa",
        props: {
          prependIcon: mdiWarehouse,
          link: "/inventory",
        },
      },
      {
        value: 2,
        title: "Hóa đơn",
        props: { prependIcon: mdiCashMultiple, link: "/invoice" },
      },
      {
        value: 3,
        title: "Nhân viên",
        props: { prependIcon: mdiAccountCircleOutline, link: "/employee" },
      },
    ]);

    return {
      items
    };
  },
});
