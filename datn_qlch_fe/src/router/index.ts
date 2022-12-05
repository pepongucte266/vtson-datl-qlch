import { createRouter, createWebHistory } from "vue-router";
import TheSaleProductContent from "../components/content/TheSaleProductContent/TheSaleProductContent.vue"
import TheReport from '../components/content/TheReport/TheReport.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: TheSaleProductContent,
    },
    {
      path: "/invoices",
      name: "invoices",
      component: TheReport,
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
