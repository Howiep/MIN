<template>
<div>
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
  },
  computed: {
    computedDateFormatted () {
      return this.formatDate(this.date)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
