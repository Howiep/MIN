<template>
  <div class="hello">
    <v-layout row justify-center>
        <v-btn class="addButton" absolute right fab color="primary" dark @click.stop="dialog = true"><v-icon dark>add</v-icon></v-btn>
        <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition" scrollable>
          <v-card tile class="stepperCard">
            <v-toolbar card dark color="primary">
              <v-btn icon @click.native="dialog = false" dark>
                <v-icon>close</v-icon>
              </v-btn>
              <v-toolbar-title>{{ msg }}</v-toolbar-title>
              <v-spacer></v-spacer>
              <v-toolbar-items>
                <v-btn dark flat @click.native="dialog = false">Save</v-btn>
              </v-toolbar-items>
            </v-toolbar>
              <create-stepper v-on:closeMenu="closeDialog"></create-stepper>
            <div style="flex: 1 1 auto;"></div>
          </v-card>
        </v-dialog>
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
    'create-stepper': () => import(/* webpackChunkName: "createStepper" */ '@/components/experience/steps/CreateStepper')
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
.addButton{
  bottom: 75px;
}
.stepperCard{
  height: 100%;
}
</style>
