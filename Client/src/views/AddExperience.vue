<template>
  <div>
    <v-layout row justify-center>
          <v-flex class="stepperCard" >
              <create-stepper v-on:closeMenu="closeDialog"></create-stepper>
            <div style="flex: 1 1 auto;"></div>
          </v-flex>
      </v-layout>
  </div>
</template>

<script>

export default {
  name: 'addExperience',
  data () {
    return {
      msg: 'Ny erfaring',
      dialog: false,
      e6: 1
    }
  },
  components: {
    'create-stepper': () => import('@/components/experience/steps/CreateStepper')
  },
  methods: {
    closeDialog (dialogStatus) {
      this.dialog = dialogStatus
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
