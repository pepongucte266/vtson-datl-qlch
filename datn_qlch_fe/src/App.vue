<script lang="ts">
import { RouterLink, RouterView } from "vue-router";
import TheSaleControl from "./components/navbar/TheSaleControl/TheSaleControl.vue";
import { useCommonStore } from "@/stores";
export default {
  components: {
    TheSaleControl,
  },
};
</script>

<template>
  <v-app class="overflow-hidden">
    <router-view name="left"></router-view>
    <router-view name="header"></router-view>
    <router-view name="right"></router-view>
    <v-main>
      <v-container fluid class="qlch-content">
        <router-view> </router-view>
      </v-container>
    </v-main>
    <v-overlay
      :model-value="commonStore.overlay"
      persistent
      class="align-center justify-center"
    >
      <v-progress-circular
        indeterminate
        size="64"
        color="primary"
      ></v-progress-circular>
    </v-overlay>
  </v-app>
</template>

<script setup lang="ts">
  const commonStore = useCommonStore();
</script>

<style>
html {
  overflow-y: hidden;
}

.qlch-content {
  background-color: #edeff2;
  height: 100%;
  padding-top: 0 !important;
}
</style>
