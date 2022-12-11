<style lang="scss" src="./TheHeaderMenu.scss"></style>
<template>
  <v-dialog v-model="show" class="qlch-dialog-header-menu">
    <v-card class="qlch-header-menu rounded-xl">
      <v-container class="grey lighten-5 pr-0">
        <v-row no-gutters>
          <v-col v-for="item in dataMenu" class="ma-4" >
            <div class="qlch-button d-flex justify-center align-center">
              <v-btn class="mb-2" elevation="2" fab large :to="item.link"  >
                <v-icon :icon="item.icon"></v-icon>
              </v-btn>
              <span class="text-center">{{ item.name }}</span>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </v-card>
  </v-dialog>
</template>

<script src="./TheHeaderMenu.ts" lang="ts"></script>
