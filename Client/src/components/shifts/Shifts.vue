<template>
  <div>
    <v-card v-for="shift in shifts" :key="shift.id" color="" class="mb-4">
      <v-card-text>
        <div class="title">{{shift.date}}</div>
        <div>{{ shift.note }}</div>
      </v-card-text>
      <v-btn flat small>Se mere</v-btn>
    </v-card>
  </div>
</template>

<script>
import ShiftsService from '@/services/ShiftsService'

export default {
	name: "shifts",
	data() {
		return {
      msg: "shifts",
      shifts: []
		}
	},
  async mounted () {
    try {
      const shifts = await ShiftsService.get()
      this.shifts = shifts.data
    } catch (error) {
      // this.message = error.response.data.error
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
</style>
