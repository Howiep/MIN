<template>
<v-container xs-fluid>
  <v-layout>
    <v-flex>
      <div class="hello">
          <h1>{{ msg }}</h1>
          <h2>Homepage</h2>
          <v-btn class="addButton" absolute right fab color="primary" dark to="experiences-add"><v-icon dark>add</v-icon></v-btn>
      </div>
    </v-flex>
  </v-layout>
</v-container>
</template>

<script>
// import * as d3 from 'd3'

export default {
  name: 'home',
  data () {
    return {
      msg: 'Home / Dashboard'
    }
  },
  components: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.addButton{
  bottom: 75px;
}
</style>
