<template>
  <div id="app">
   <v-app>
     <page-top-nav/>
      <v-content>
          <router-view></router-view>
      </v-content>
      <page-bottom-nav app/>
  </v-app>
</div>
</template>

<script>
import PageBottomNav from '@/components/shared/BottomNav.vue'
import PageTopNav from '@/components/shared/TopNav.vue'

export default {
  name: 'app',
  components: {
    PageBottomNav,
    PageTopNav
  }
}
</script>

<style>

</style>
