<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <v-app>
    <v-app-bar height="48" color="grey" elevation="0"></v-app-bar>
    <v-navigation-drawer location="right" width="300" color="grey-lighten-1" permanent></v-navigation-drawer>
    <v-main>
      <v-card elevation="0" height="400px">
      </v-card>
    </v-main>
  </v-app>

</template>

<style scoped>
</style>
