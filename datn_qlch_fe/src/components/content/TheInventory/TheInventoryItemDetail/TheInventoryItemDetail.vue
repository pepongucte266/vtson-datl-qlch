<style lang="scss" src="./TheInventoryItemDetail.scss"></style>

<template>
  <v-row justify="center">
    <v-dialog v-model="show" persistent width="1400px">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props"> Thông tin hàng hóa </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="text-h5">Thông tin hàng hóa</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Tên hàng hóa*" v-model="inventoryItem.InventoryItemName" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Mã hàng hóa*" v-model="inventoryItem.InventoryItemCode" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Nhóm hàng hóa"  required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Giá bán" v-model="inventoryItem.InventoryItemPrice" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-autocomplete
                  v-model="inventoryItem.InventoryItemUnitID"
                  :items="inventoryItemUnits"
                  item-title="InventoryItemUnitName"
                  item-value="InventoryItemUnitID"
                  label="Đơn vị tính cơ bản"
                ></v-autocomplete>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Tồn kho" v-model="inventoryItem.Quantity" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Đường dẫn ảnh" v-model="inventoryItem.InventoryItemImage" required></v-text-field>
                <v-text-field label="Mô tả" v-model="inventoryItem.Description"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="8">
                <v-table fixed-header height="300px">
                  <thead>
                    <tr>
                      <th class="text-left">Tên đơn vị tính</th>
                      <th class="text-left">Tỷ lệ quy đổi</th>
                      <th class="text-left">Mổ tả</th>
                      <th class="text-left">Giá</th>
                      <th class="text-left">Đơn vị bán mặc định</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="item in desserts" :key="item.name">
                      <td>{{ item.name }}</td>
                      <td>{{ item.calories }}</td>
                      <td>{{ item.calories }}</td>
                      <td>{{ item.calories }}</td>
                      <td>
                        <v-checkbox
                          v-model="testtttt"
                          label=""
                          required
                        ></v-checkbox>
                      </td>
                    </tr>
                  </tbody>
                </v-table>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="handlerSaveBtn">
            Lưu
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="show = false">
            Đóng
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script src="./TheInventoryItemDetail.ts" lang="ts"></script>
