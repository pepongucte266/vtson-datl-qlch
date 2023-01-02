import { createRouter, createWebHistory } from "vue-router";
import TheSaleProductContent from "@/components/content/TheSaleProductContent/TheSaleProductContent.vue"
import TheInventoryItemList from "@/components/content/TheInventory/TheInventoryItemList/TheInventoryItemList.vue";
import TheReport from '@/components/content/TheReport/TheReport.vue';
import TheSaleControl from '@/components/navbar/TheSaleControl/TheSaleControl.vue'
import TheNavbarSetting from '@/components/navbar/TheNavbarSetting/TheNavbarSetting.vue'
import TheEmployeeList from '@/components/content/TheEmployee/TheEmployeeList/TheEmployeeList.vue'
import TheHeader from "@/components/header/TheHeader/TheHeader.vue";
import TheLogin from "@/components/login/TheLogin.vue";
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      components: {
        default: TheSaleProductContent,
        right: TheSaleControl,
        header: TheHeader
      },
    },
    {
      path: "/invoices",
      name: "invoices",
      components: {
        default: TheReport,
        right: TheSaleControl,
        header: TheHeader
      },
    },
    {
      path: "/inventory",
      name: "inventory",
      components: {
        default: TheInventoryItemList,
        left: TheNavbarSetting,
        header: TheHeader
      },
    },
    {
      path: "/invoice",
      name: "invoice",
      components: {
        default: TheReport,
        left: TheNavbarSetting,
        header: TheHeader
      },
    },
    {
      path: "/employee",
      name: "employee",
      components: {
        default: TheEmployeeList,
        left: TheNavbarSetting,
        header: TheHeader
      },
    },
    {
      path: "/login",
      name: "login",
      components: {default: TheLogin}
    },
    // {
    //   path: "/about",
    //   name: "about",
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import("../views/AboutView.vue"),
    // },
  ],
});

export default router;
