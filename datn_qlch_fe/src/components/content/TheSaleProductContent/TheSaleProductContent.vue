<style lang="scss" src="./TheSaleProductContent.scss"></style>
<template>
  <div class="the-sale-product-content rounded-xl" >
    <div class="the-sale-product-header">
      <div class="the-sale-product-search">
        <v-combobox
          :items="['Foo', 'Bar']"
          label="Tìm kiếm hàng hóa"
        ></v-combobox>
      </div>
    </div>
    <div class="the-sale-product-table">
        <v-row class="product-table-row" v-for="item in items" :key="item.InventoryItemName">
          <v-col>{{item.InventoryItemCode}}</v-col>
          <v-col>{{item.InventoryItemName}}</v-col>
          <v-col>{{item.Quantity}}</v-col>
          <v-col>{{item.UnitPrice}}</v-col>
          <v-col>{{item.Price}}</v-col>
        </v-row>
      </div>
  </div>
</template>
<script src="./TheSaleProductContent.ts" lang="ts"></script>>
