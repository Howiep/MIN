<template>
<v-container xs-fluid>
   <v-layout>
    <v-flex>
      <div class="hello">
          <shifts></shifts>
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
    }
  },
  components: {
    'add-dialog': () => import(/* webpackChunkName: "addDialog" */ '@/components/experience/AddExperience'),
    'shifts': () => import(/* webpackChunkName: "addDialog" */ '@/components/shifts/Shifts')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
