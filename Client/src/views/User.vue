<template>
<v-container xs-fluid>
    <v-layout>
    <v-flex>
      <div class="hello">
          <h1>{{ msg }}</h1>
          <h2>User: {{ userName }}</h2>
      </div>
    </v-flex>
  </v-layout>
</v-container>
</template>

<script>
import store from '@/store'
import AuthenticationService from '@/services/AuthenticationService'

export default {
  name: 'home',
  data () {
    return {
      msg: 'Bruger',
      userName: 'howie'
    }
  },
  async mounted () {
      try {
        const response = await AuthenticationService.getUser()
        console.log(response.data.result)
        this.userName = response.data.result.userName
      } catch (error) {
        //console.log(error)
      }
  },
  computed: {
    token () {
      return store.state.user.token
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
