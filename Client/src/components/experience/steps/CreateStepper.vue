<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step editable step="1" :complete="e1 > 1">Vælg Tidspunkt</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step editable step="2" :complete="e1 > 2">Vælg Aktivitet</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="3">Noter<small>Valgfrit</small></v-stepper-step>
    </v-stepper-header>
    <v-stepper-items class="stepperCard">
      <v-stepper-content step="1">
        <choose-date v-on:setDate="setDate"></choose-date>
        <p v-if="dateFormatted">Du har valgt: {{ dateFormatted }}</p>
        <v-btn color="primary" @click.native="e1 = 2">Fortsæt</v-btn>
        <v-btn flat @click="closeMenu()">Annuller</v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <div class="mb-5">
          <choose-experience v-on:setExperiences="setExperiences"></choose-experience>
        </div>
        <v-btn color="primary" @click.native="e1 = 3">Fortsæt</v-btn>
        <v-btn flat @click.native="e1 = e1 - 1">Tilbage</v-btn>
      </v-stepper-content>

      <v-stepper-content step="3">
        <div class="mb-5">
          <v-text-field multi-line label="Indsæt note" v-model="createNote">

          </v-text-field>
        </div>
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
      e1: 1,
      createNote: '',
      selectedExperiences: [],
      dateFormatted: null
    }
  },
  methods: {
    closeMenu () {
      this.$emit('closeMenu', this.dialog)
    },
    setExperiences (selected) {
      this.selectedExperiences = selected
    },
    setDate (date) {
      this.dateFormatted = date
    }
  },
  components: {
    'choose-date': () => import('@/components/experience/steps/ChooseDate'),
    'choose-experience': () => import('@/components/experience/steps/ChooseExperience')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.stepperCard > div{
  height: 100%;
}
</style>
