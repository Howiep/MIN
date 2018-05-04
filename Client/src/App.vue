<template>
<div id="app">
   <v-app>
     <page-top-nav/>
      <v-content>
        <v-container xs-fluid >
          <router-view></router-view>
        </v-container>
         <!-- Todo: add if(loggedin), so nav is hidden on first load -->
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
body {
  margin: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

</style>
