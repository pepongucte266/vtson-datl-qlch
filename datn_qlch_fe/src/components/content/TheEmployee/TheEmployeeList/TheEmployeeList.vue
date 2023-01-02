<style lang="scss" src="./TheEmployeeList.scss"></style>

<template>
  <div class="employee-content">
    <div class="employee-header">
      <div class="employee-title">
        <span>Danh sách nhân viên</span>
      </div>
      <div class="employee-action">
        <v-btn
          color="success"
          :prepend-icon="mdiArchivePlusOutline"
          class="d-flex align-center"
          @click="openEmployeeDetail(Enum.Action.Insert)"
        >
          Thêm
        </v-btn>
      </div>
    </div>

    <div class="inventory-body">
      <v-table fixed-header class="inventory-table" height="80vh">
        <thead class="inventory-table-header">
          <tr>
            <th class="text-left" style="font-size: large">STT</th>
            <th class="text-left" style="font-size: large">Tên nhân viên</th>
            <th class="text-left" style="font-size: large">Số điện thoại</th>
            <th class="text-left" style="font-size: large">Ngày sinh</th>
            <th class="text-left" style="font-size: large">Chức vụ</th>
            <th class="text-left" style="font-size: large">Địa chỉ</th>
            <th class="text-left" style="font-size: large"></th>
            <th class="text-left" style="font-size: large"></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="item,index in employees"
            :key="item.EmployeeID"
          >
            <td>{{ index }}</td>
            <td>{{ item.EmployeeName }}</td>
            <td>{{ item.PhoneNumber }}</td>
            <td>{{ Commonfunction.formatDate(item.DateOfBirth) }}</td>
            <td>{{ item.Role }}</td>
            <td>{{ item.Address }}</td>
            <td>
              <v-icon
                :icon="mdiDelete"
                class="employee-table-btn-delete"
                color="red-lighten-2"
                @click="deleteEmployee(item)"
              ></v-icon>
            </td>
            <td>
              <v-icon
                :icon="mdiNoteEdit"
                class="employee-table-btn-delete"
                color="blue-lighten-2"
              ></v-icon>
            </td>
          </tr>
        </tbody>
      </v-table>
    </div>
  </div>

  <QLCHDialog
    v-if="showDialog"
    :title="dialogTitle"
    :message="dialogMessage"
    :isShow="showDialog"
    @isShowDialog="showDialog = $event"
    ref="qlchDialog"
  ></QLCHDialog>

  <TheEmployeeDetail
    v-if="showEmployeeDetail"
    :showEmployeeDetail="showEmployeeDetail"
    :employeeID="currentEmployeeID"
    @change="showEmployeeDetail = $event"
    :action="action"
  ></TheEmployeeDetail>
</template>

<script src="./TheEmployeeList.ts" lang="ts"></script>
