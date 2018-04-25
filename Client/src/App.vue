<template>
<div id="app">
   <v-app>
    <page-header />
      <main>
        <v-container fluid>
          <router-view></router-view>
        </v-container>
      </main>
  </v-app>
</div>
 
</template>
<script>
import PageHeader from '@/components/Header.vue'

export default {
  name: 'app',
  components: {
    PageHeader
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
main{
  padding-top: 100px;
}

</style>
