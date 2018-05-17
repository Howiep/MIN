<template>
      <div>
          <h1>{{ msg }}</h1>
          <h2>component</h2>
      </div>
</template>

<script>
import BabyService from '@/services/BabyService'

export default {
  name: 'babies',
  data () {
    return {
      msg: 'babies',
      babies: [],
      sortedBabies: []
    }
  },
  async mounted () {
    try {
      const res = await BabyService.get()
      this.babies = res
    } catch (error) {
      this.message = error.response.data.error
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
