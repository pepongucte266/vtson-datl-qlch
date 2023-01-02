<style scoped lang="scss" src="./QLCHDialog.scss"></style>

<template>
  <v-dialog
      v-model="show"
      width="500px"
    >
      <v-card :title="title">
        <v-card-text v-html="message">
        </v-card-text>
        <v-card-actions class="d-flex justify-end">
          <v-btn color="primary" @click="confirm">Đồng ý</v-btn>
          <v-btn color="primary" @click="cancel">Đóng</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
</template>

<script lang="ts" src="./QLCHDialog.ts"></script>
