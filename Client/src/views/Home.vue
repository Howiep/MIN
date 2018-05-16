<template>
<v-container xs-fluid>
  <v-layout>
    <v-flex>
      <div class="hello">
          <h1>{{ msg }}</h1>
          <h2>Homepage</h2>
          <add-dialog></add-dialog>
      </div>
    </v-flex>
  </v-layout>
</v-container>
</template>

<script>
// import * as d3 from 'd3'
import AddDialog from '@/components/experience/AddExperience.vue'

export default {
  name: 'home',
  data () {
    return {
      msg: 'Home / Dashboard'
    }
  },
  components: {
    AddDialog
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
