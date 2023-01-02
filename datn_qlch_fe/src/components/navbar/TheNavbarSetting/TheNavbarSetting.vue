<style lang="scss" src="./TheNavbarSetting.scss"></style>

<template>
  <v-navigation-drawer width="250" permanent class="navbar-setting">
    <v-list>
      <v-list :items="items" rounded="xl" active-color="yellow">
        <template v-slot:item="item">
          <v-list-item :value="item" :to="item.link">
            <template v-slot:prepend>
              <v-list-item :prepend-icon="item.prependIcon"></v-list-item>
            </template>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </template>
      </v-list>
    </v-list>
  </v-navigation-drawer>
</template>

<script src="./TheNavbarSetting.ts" lang="ts"></script>
