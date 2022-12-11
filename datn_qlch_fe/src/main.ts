import { createApp } from "vue";
import { createPinia } from "pinia";
// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { aliases, mdi } from 'vuetify/iconsets/mdi-svg'

//Axios
import axios from 'axios'
import VueAxios from 'vue-axios'

import App from "./App.vue";
import router from "./router";

import "./assets/main.css";

const vuetify = createVuetify({
  components,
  directives,
  icons: {
    defaultSet: 'mdi',
    aliases,
    sets: {
      mdi,
    },
  },
})

const app = createApp(App);

app.use(createPinia());
app.use(VueAxios, axios)
app.use(router);
app.use(vuetify);

app.mount("#app");
