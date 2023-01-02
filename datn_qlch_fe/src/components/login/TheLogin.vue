<style lang="scss" src="./TheLogin.scss"></style>
<template>
  <div>
    <v-sheet class="login-page bg-deep-purple pa-12" rounded>
      <v-card width="400px" class="mx-auto px-6 py-8" max-width="344">
        <v-card-title>Đăng nhập</v-card-title>
        <v-form v-model="form" @submit.prevent="onSubmit">
          <v-text-field
            v-model="phonenumber"
            :readonly="loading"
            :rules="[required]"
            class="mb-2"
            clearable
            label="SĐT"
          ></v-text-field>

          <v-text-field
            v-model="password"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Password"
            type="password"
            placeholder="Enter your password"
          ></v-text-field>

          <br />

          <v-btn
            :disabled="!form"
            :loading="loading"
            block
            color="success"
            size="large"
            type="submit"
            variant="elevated"
          >
            Đăng nhập
          </v-btn>
        </v-form>
      </v-card>
    </v-sheet>
  </div>
</template>
<script src="./TheLogin.ts" lang="ts"></script>
