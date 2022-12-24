<style scoped lang="scss" src="./TheHeader.scss"></style>
<template>
  <v-app-bar class="qlch-header px-4" height="56" color="grey" elevation="0">
    <v-row align="start">
      <v-col>
        <div>Bán hàng</div>
      </v-col>
      <v-col class="d-flex justify-end">
        <div>
          <v-icon
            class="mx-4"
            :style="{ cursor: 'pointer' }"
            :icon="mdiAccount"
          />
          Boss Sơn
          <v-icon
            class="ml-4"
            :icon="mdiApps"
            @click="showPopupHeaderMenu = true"
          />
        </div>
        <TheHeaderMenu
          v-if="showPopupHeaderMenu"
          @update:showPopupHeaderMenu="showPopupHeaderMenu = $event"
          :showPopupHeaderMenu="showPopupHeaderMenu"
        ></TheHeaderMenu>
      </v-col>
    </v-row>
  </v-app-bar>
</template>

<script lang="ts" src="./TheHeader.ts"></script>
