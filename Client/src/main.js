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
    primary: '#7D86F0',
    accent: '#A576EF',
    darkGrey: '#3C3C3C',
    whiteText: '#ececec',
    underline: '#F4D63C',
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
