<style lang="scss" src="./TheInventoryItemList.scss"></style>

<template>
  <div class="inventory-content">
    <div class="inventory-header">
      <div class="inventory-title">
        <span>Danh sách hàng hóa</span>
      </div>
      <div class="inventory-action">
        <v-btn
          color="success"
          :prepend-icon="mdiArchivePlusOutline"
          class="d-flex align-center"
          @click="openInventoryItemDetail(Enum.Action.Insert)"
        >
          Thêm
        </v-btn>
      </div>
    </div>
    
    <div class="inventory-body">
      <v-table fixed-header class="inventory-table" height="80vh">
        <thead class="inventory-table-header">
          <tr>
            <th class="text-left" style="font-size: large">Code</th>
            <th class="text-left" style="font-size: large">Tên hàng hóa</th>
            <th class="text-left" style="font-size: large">Nhóm hàng hóa</th>
            <th class="text-left" style="font-size: large">Đơn vị tính</th>
            <th class="text-left" style="font-size: large">Trạng thái</th>
            <th class="text-left" style="font-size: large"></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="item in inventoryItems"
            :key="item.InventoryItemID"
            @dblclick="
              openInventoryItemDetail(Enum.Action.Edit, item.InventoryItemID)
            "
          >
            <td>{{ item.InventoryItemCode }}</td>
            <td>{{ item.InventoryItemName }}</td>
            <td>{{ item.InventoryItemCategoryName }}</td>
            <td>{{ item.InventoryItemUnitName }}</td>
            <td>
              {{
                item.InventoryItemStatus == Enum.InventoryIitemStatus.Active
                  ? "Còn hàng"
                  : "Hết hàng"
              }}
            </td>
            <td>
              <v-icon
                @click="deleteInventoryItem(item)"
                :icon="mdiDelete"
                class="inventory-table-btn-delete"
                color="red-lighten-2"
              ></v-icon>
            </td>
            <td>
              <v-icon
                @click="
                  openInventoryItemDetail(
                    Enum.Action.Edit,
                    item.InventoryItemID
                  )
                "
                :icon="mdiNoteEdit"
                class="inventory-table-btn-delete"
                color="blue-lighten-2"
              ></v-icon>
            </td>
          </tr>
        </tbody>
      </v-table>
    </div>
  </div>

  <v-snackbar
    :color="toastColor"
    v-model="toastBox"
    class="d-flex justify-center"
  >
    <span>Xóa hàng hóa thành công</span>
  </v-snackbar>

  <QLCHDialog
    v-if="showDialog"
    :title="dialogTitle"
    :message="dialogMessage"
    :isShow="showDialog"
    @isShowDialog="showDialog = $event"
    ref="qlchDialog"
  ></QLCHDialog>

  <TheInventoryItemDetail
    v-if="showInventoryItemDetail"
    :showInventoryItemDetail="showInventoryItemDetail"
    @change="showInventoryItemDetail = $event"
    :action="action"
    :inventoryItemID="currentInventoryItemID"
  ></TheInventoryItemDetail>

</template>

<script src="./TheInventoryItemList.ts" lang="ts"></script>
