<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step editable step="1" :complete="e1 > 1">Vælg Tidspunkt</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step editable step="2" :complete="e1 > 2">Vælg Aktivitet</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="3">Beskrivelse<small>Valgfrit</small></v-stepper-step>
    </v-stepper-header>
    <v-stepper-items>
      <v-stepper-content step="1">
        <v-card color="grey lighten-1" class="mb-5" height="200px"></v-card>
        <v-btn color="primary" @click.native="e1 = 2">Fortsæt</v-btn>
        <v-btn flat @click="closeMenu()">Annuller</v-btn>
      </v-stepper-content>
      <v-stepper-content step="2">
        <v-card color="grey lighten-1" class="mb-5" height="200px"></v-card>
        <v-btn color="primary" @click.native="e1 = 3">Fortsæt</v-btn>
        <v-btn flat @click.native="e1 = e1 - 1">Tilbage</v-btn>
      </v-stepper-content>
      <v-stepper-content step="3">
        <v-card color="grey lighten-1" class="mb-5" height="200px"></v-card>
        <v-btn color="primary" @click="closeMenu()">Færdig</v-btn>
        <v-btn flat @click.native="e1 = e1 - 1">Tilbage</v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script>
export default {
  name: 'createStepper',
  data () {
    return {
      e1: 0
    }
  },
  methods: {
    closeMenu () {
      this.$emit('closeMenu', this.dialog)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
