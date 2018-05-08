// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import Vuetify from 'vuetify'
import { sync } from 'vuex-router-sync'
import 'vuetify/dist/vuetify.min.css'
import store from '@/store/store'

Vue.config.productionTip = false

Vue.use(Vuetify, {
  theme: {
    primary: '#b06a92',
    accent: '#45BA3F',
    darkGrey: '#3C3C3C',
    whiteText: '#ececec',
    underline: '#45BA3F',
    green: '#20D74B'
  }
})

sync(store, router)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
  store
})
