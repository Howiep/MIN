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
export default {
  name: 'experiences',
  data () {
    return {
      msg: 'Experiences'
    }
  },
  components: {
    'add-dialog': () => import(/* webpackChunkName: "addDialog" */ '@/components/experience/AddExperience')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
