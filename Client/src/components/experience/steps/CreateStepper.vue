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
            <v-dialog ref="dateDialog" v-model="modal" :return-value.sync="date" persistent lazy full-width width="290px">
              <v-text-field slot="activator" v-model="date" label="Vælg Dato" prepend-icon="event" readonly></v-text-field>
              <v-date-picker v-model="date" scrollable>
                <v-spacer></v-spacer>
                <v-btn flat color="primary" @click="modal = false">Cancel</v-btn>
                <v-btn flat color="primary" @click="$refs.dateDialog.save(date)">OK</v-btn>
              </v-date-picker>
            </v-dialog>
        </div>
        <div>
           <v-dialog ref="timeDialog" persistent v-model="modal2" lazy full-width width="290px" :return-value.sync="time">
            <v-text-field slot="activator" label="Vælg Tid" v-model="time" prepend-icon="access_time" readonly
            ></v-text-field>
            <v-time-picker v-model="time" actions>
              <v-spacer></v-spacer>
              <v-btn flat color="primary" @click="modal2 = false">Cancel</v-btn>
              <v-btn flat color="primary" @click="$refs.timeDialog.save(time)">OK</v-btn>
            </v-time-picker>
          </v-dialog>
        </div>
        <p v-if="dateTime">Du har valgt: {{ dateTime }}</p>
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
      date: null,
      time: null,
      dateTime: '',
      modal: false,
      modal2: false
    }
  },
  watch: {
    time () {
      this.chooseTime()
    }
  },
  methods: {
    closeMenu () {
      this.$emit('closeMenu', this.dialog)
    },
    chooseTime () {
      this.formatDate(this.date)
      this.dateTime = this.date + ' ' + this.time
      this.formatDate(this.dateTime)
      console.log(this.dateTime)
    },
    formatDate (str) {
      return str.split('-').reverse().join('-')
    }
  },
  components: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
