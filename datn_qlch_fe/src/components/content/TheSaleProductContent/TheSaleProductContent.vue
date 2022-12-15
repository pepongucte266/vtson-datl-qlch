<style lang="scss" src="./TheSaleProductContent.scss"></style>
<template>
  <div style="position: relative; height: 100%">
    <div class="the-sale-product-content rounded-xl">
      <div class="the-sale-product-header">
        <div class="the-sale-product-search">
          <v-combobox
            :items="['Foo', 'Bar']"
            label="Tìm kiếm hàng hóa"
          ></v-combobox>
        </div>
      </div>
      <div class="the-sale-product-table">
        <v-row
          class="product-table-row"
          v-for="item in inventoryItemStore.inventoryItemOnSale"
          :key="item.InventoryItemName"
        >
          <v-col>{{ item.InventoryItemCode }}</v-col>
          <v-col>{{ item.InventoryItemName }}</v-col>
          <v-col>{{ item.Quantity }}</v-col>
          <v-col>{{ item.UnitPrice }}</v-col>
          <v-col>{{ item.Price }}</v-col>
        </v-row>
      </div>
    </div>
    <v-app-bar height="350" location="bottom" class="the-sale-product-list">
      <v-window v-model="onboarding" show-arrows="hover">
        <v-window-item v-for="page,index in dataPaging" :key="`card-${index}`">
          <v-card
            elevation="2"
            height="350"
            class="d-flex justify-center align-center flex-wrap ma-2 list-product-container"
          >
            <v-card
              elevation="2"
              height="145"
              width="235"
              class="d-flex flex-column justify-space-between ma-2 rounded-lg"
              v-for="inventoryItem in page"
              :key="inventoryItem.InventoryItemID"
              @click="addInventoryItemToInvoice(inventoryItem)"
            >
              <v-img
                :src="inventoryItem.InventoryItemImage"
                max-height="115"
                height="115"
                class="grey darken-4"
              ></v-img>
              <div class="product-name ml-2">
                {{ inventoryItem.InventoryItemName }}
              </div>
            </v-card>
          </v-card>
        </v-window-item>
      </v-window>
    </v-app-bar>
  </div>
</template>
<script src="./TheSaleProductContent.ts" lang="ts"></script>
>
