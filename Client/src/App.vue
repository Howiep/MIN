<template>
<div id="app">
   <v-app>
      <main>
        <v-container fluid>
          <router-view></router-view>
        </v-container>
        <page-Nav />
      </main>
  </v-app>
</div>
 
</template>
<script>
import PageNav from '@/components/shared/Nav.vue'

export default {
  name: 'app',
  components: {
    PageNav
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
/* main{
  padding-top: 100px;
} */

</style>
