<script lang="ts">
import { RouterLink, RouterView } from "vue-router";
import TheHeader from "./components/header/TheHeader/TheHeader.vue";
import TheSaleControl from "./components/navbar/TheSaleControl/TheSaleControl.vue";
export default {
  components: {
    TheHeader,
    TheSaleControl
  },
};
</script>

<template>
  <v-app class="overflow-hidden">
    <TheHeader></TheHeader>
    <TheSaleControl></TheSaleControl>
    <v-main>
      <v-container fluid class="qlch-content">
        <router-view></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<style>
html {
  overflow-y: auto;
}

.qlch-content {
  background-color: #EDEFF2;
  height: 100%;
}
</style>
