<style lang="scss" src="./TheEMployeeDetail.scss"></style>

<template>
  <v-row justify="center">
    <v-dialog v-model="show" persistent width="1400px">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props"> Thông tin nhân viên </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="text-h5">Thông tin nhân viên</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Tên nhân viên*"
                  v-model="employee.EmployeeName"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Số điện thoại*"
                  v-model="employee.PhoneNumber"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-menu
                  v-model="menu2"
                  :close-on-content-click="false"
                  transition="scale-transition"
                  offset-y
                  max-width="290px"
                  min-width="auto"
                >
                  <template v-slot:activator>
                    <v-text-field
                      :value="computedDate"
                      label="Date (read only text field)"
                      hint="MM/DD/YYYY format"
                      persistent-hint
                      readonly
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="employee.DateOfBirth"
                    no-title
                    @input="menu2 = false"
                  ></v-date-picker>
                </v-menu>
              </v-col>
              <v-row justify="center">
                <v-date-picker v-model="picker"></v-date-picker>
              </v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Chức vụ"
                  v-model="employee.Role"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Mật khẩu*"
                  v-model="employee.Password"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Địa chỉ"
                  v-model="employee.Address"
                  required
                ></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="show = false">
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

<script src="./TheEMployeeDetail.ts" lang="ts"></script>
