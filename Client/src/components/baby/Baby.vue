<template>
      <div>
        <v-list two-line>
          <template v-for="(item, index) in babies">
            <v-list-tile v-if="item.id" :key="index" avatar>
              <v-list-tile-avatar>
                <p>{{item.BirthDay | byDate}}</p>
              </v-list-tile-avatar>
              <v-list-tile-content>
                <v-list-tile-title v-html="item.Location"></v-list-tile-title>
                <v-list-tile-sub-title v-html="item.gender"></v-list-tile-sub-title>
              </v-list-tile-content>
            </v-list-tile>
          </template>
        </v-list>
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
  },
  methods:{
    sortBabies: function(){
      this.sortedBabies = this.babies.filter(byDate)
      console.log(this.sortedBabies)
    }
  },
  filters: {
  byDate: function (value) {
      const date = new Date(value)
      //Look https://www.youtube.com/watch?v=X8mpO9Fn2_Y
      return date.toLocaleString(['da-DK'], {month: '2-digit', day: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit'})
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
