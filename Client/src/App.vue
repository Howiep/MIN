<template>
  <div id="app">
   <v-app>
     <page-top-nav v-if="this.isLoggedIn" app/>
      <v-content class="black--text">
          <router-view></router-view>
      </v-content>
      <page-bottom-nav v-if="this.isLoggedIn" app/>
      <v-snackbar
              :timeout="snackContent.timeout"
              :color="snackContent.snackColor"
              vertical
              v-model="snackContent.snackbarStatus" >
              {{ snackContent.message }}
    </v-snackbar>
  </v-app>
</div>
</template>

<script>
import store from '@/store'
import PageBottomNav from '@/components/shared/BottomNav.vue'
import PageTopNav from '@/components/shared/TopNav.vue'

export default {
  name: 'app',
  data () {
    return {
    }
  },
  components: {
    PageBottomNav,
    PageTopNav
  },
  computed: {
    isLoggedIn () {
      return store.state.isLoggedIn
    },
    snackContent () {
      return store.state.snackContent
    }
  }
}
</script>

<style>
</style>
