<template>
<div>
   <div>
        <v-dialog ref="dateDialog" v-model="modal" :return-value.sync="date" persistent lazy full-width width="290px">
          <v-text-field slot="activator" v-model="date" label="Vælg Dato" prepend-icon="event" readonly></v-text-field>
          <v-date-picker v-model="date" no-title scrollable>
            <v-spacer></v-spacer>
            <v-btn flat color="primary" @click="modal = false">Cancel</v-btn>
            <v-btn flat color="primary" @click="$refs.dateDialog.save(date)">OK</v-btn>
          </v-date-picker>
        </v-dialog>
    </div>
  </div>
</template>

<script>
export default {
  name: 'chooseDate',
  data () {
    return {
      msg: 'choose date',
      date: null,
      dateFormatted: null,
      modal: false
    }
  },
  async mounted () {
    try {
      let today = new Date()
      let dd = today.getDate()
      let mm = today.getMonth()+1 //January is 0!
      let yyyy = today.getFullYear()
      if(dd<10) {
          dd = '0'+dd
      }

      if(mm<10) {
          mm = '0'+mm
      }
      today = yyyy + '-' + mm + '-' + dd
      this.date = today
    } catch (error) {
      console.log(error)
    }
  },
  watch: {
    date () {
      this.dateFormatted = this.formatDate(this.date)
      this.$emit('setDate', this.dateFormatted)
    }
  },
  methods: {
    formatDate (date) {
      if (!date) return null

      const [year, month, day] = date.split('-')
      return `${day}/${month}/${year}`
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
