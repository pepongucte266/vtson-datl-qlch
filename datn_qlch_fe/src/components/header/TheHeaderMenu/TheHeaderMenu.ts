import { defineComponent, ref, computed } from "vue";
import { mdiApps, mdiCogOutline, mdiLogout } from "@mdi/js";
export default defineComponent({
  props: {
    showPopupHeaderMenu: Boolean,
  },
  setup(props, { emit }) {
    //Biến hiển thi popup
    var show = computed<boolean>({
      get() {
        return props.showPopupHeaderMenu;
      },
      set(value) {
        emit("update:showPopupHeaderMenu", value);
      },
    });
    const dataMenu = ref([
      {
        name: "Bán hàng",
        icon: mdiApps,
        link: "/",
      },
      {
        name: "DS hóa đơn",
        icon: mdiApps,
        link: "/invoices",
      },
      {
        name: "Báo cáo",
        icon: mdiApps,
        link: "/",
      },
      {
        name: "Thu chi",
        icon: mdiApps,
        link: "/",
      },
      {
        name: "Quản lý",
        icon: mdiCogOutline,
        link: "/inventory",
      },
      {
        name: "Đăng xuất",
        icon: mdiLogout,
        link: "/login",
      },
    ]);
    return {
      show,
      dataMenu,
      mdiApps,
    };
  },
});
