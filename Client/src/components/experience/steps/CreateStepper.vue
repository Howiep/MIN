<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step editable step="1" :complete="e1 > 1">Vælg Tidspunkt</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step editable step="2" :complete="e1 > 2">Vælg Aktivitet</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="3">Noter<small>Valgfrit</small></v-stepper-step>
    </v-stepper-header>
    <v-stepper-items>
      <v-stepper-content step="1">
        <div>
            <v-tabs centered color="transparent" slot="extension" slider-color="yellow" v-model="model" >
              <v-tab :href="`#tab-${1}`">
                <v-icon color="darkGrey">date_range</v-icon>
                Dato
              </v-tab>
              <v-tab :href="`#tab-${2}`">
                <v-icon color="darkGrey">date_range</v-icon>
                Tid
              </v-tab>
            </v-tabs>
          <v-tabs-items v-model="model">
            <v-tab-item :id="`tab-${1}`">
              <v-card flat>
                <v-date-picker v-model="picker" :landscape="landscape" :reactive="reactive"></v-date-picker>
              </v-card>
            </v-tab-item>
            <v-tab-item :id="`tab-${2}`">
              <v-card flat>
                <v-time-picker v-model="picker" :landscape="landscape"></v-time-picker>
              </v-card>
            </v-tab-item>
          </v-tabs-items>
        </div>
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
      e1: 0,
      picker: null,
      landscape: false,
      reactive: false,
      model: 'tab-1',
      text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
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
