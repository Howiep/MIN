<template>
<v-toolbar fixed class="pink" dark>
    <v-toolbar-title class="mr-4">
        <v-btn flat href=/#/>
            tabtracker
        </v-btn>
    </v-toolbar-title>
    <v-toolbar-items>
        <v-btn flat href="/#/songs">
            browse
        </v-btn>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <v-toolbar-items>
        <v-btn flat href="/#/">home</v-btn>
    </v-toolbar-items>
    <div>
        <v-btn v-if="this.isLoggedIn" flat @click="logout">Log out</v-btn>
        <v-btn v-if="!this.isLoggedIn" flat href="/#/register">Sign up</v-btn>
        <v-btn v-if="!this.isLoggedIn" outline flat href="/#/login">Login</v-btn>
    </div>
</v-toolbar>
</template>

<script>
import store from '@/store/store'

export default {
  methods: {
    logout () {
      this.$store.dispatch('setToken', null)
      this.$store.dispatch('setUser', null)
      this.$router.push({
        name: global
      })
    }
  },
  computed: {
    isLoggedIn () {
      return store.state.isLoggedIn
    }
  }
}
</script>

<!-- Add "scoped" attribute to 
limit CSS to this component only -->
<style>

</style>
