<style lang="scss" src="./TheSaleControl.scss"></style>
<template>
  <v-navigation-drawer
    location="right"
    width="450"
    permanent
    class="sale-control"
  >
    <div class="sale-control-content pa-4 rounded-xl">
      <div class="customer-select">
        <v-autocomplete
          auto-select-first
          dense
          filled
          placeholder="SĐT, Tên khách hàng"
          rounded
        ></v-autocomplete>
      </div>
      <div class="invoice-info">
        <div class="invoice-amount d-flex justify-space-between ma-2">
          <span>Tổng tiền:</span>
          <span>{{ currentInvoice?.Amount}}</span>
        </div>
        <div class="deposit-amount d-flex justify-space-between ma-2">
          <span>Đặt cọc:</span>
          <span>0</span>
        </div>
        <div class="remain-amount d-flex justify-space-between ma-2">
          <span><strong>Còn phải thu:</strong></span>
          <span>0</span>
        </div>
        <div class="remain-amount d-flex justify-space-between ma-2">
          <span><strong>Trả lại khách:</strong></span>
          <span>0</span>
        </div>
      </div>
      <div class="btn-submit pr-8">
        <v-btn  size="x-large" color="success" block> Xác nhận </v-btn>
      </div>
    </div>
  </v-navigation-drawer>
</template>
<script src="./TheSaleControl.ts" lang="ts"></script>
