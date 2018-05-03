<template>
    <v-toolbar app dark>
    <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->
    <v-toolbar-title>title</v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items>
      <v-text-field
        label="Search"
        v-model="search"
      ></v-text-field>
      <v-btn flat icon>
        <v-icon>search</v-icon>
      </v-btn>
    </v-toolbar-items>
    <v-toolbar-items class="hidden-sm-and-down">
      <v-btn flat>Link One</v-btn>
      <v-btn flat>Link Two</v-btn>
      <v-btn flat>Link Three</v-btn>
    </v-toolbar-items>
  </v-toolbar>
    <!-- <v-toolbar-items>
        <v-btn flat href="/#/">home</v-btn>
        <v-btn v-if="this.isLoggedIn" flat @click="logout">Log out</v-btn>
        <v-btn v-if="!this.isLoggedIn" flat href="/#/register">Sign up</v-btn>
        <v-btn v-if="!this.isLoggedIn" class="primary" href="/#/login">Login</v-btn>
    </v-toolbar-items> -->
</template>

<script>
// import store from '@/store/store'

export default {
  data () {
    return {
      e1: null,
      search: ''
    }
  }
  // methods: {
  //   logout () {
  //     this.$store.dispatch('setToken', null)
  //     this.$store.dispatch('setUser', null)
  //     this.$router.push({
  //       name: global
  //     })
  //   }
  // },
  // computed: {
  //   isLoggedIn () {
  //     return store.state.isLoggedIn
  //   }
  // }
}
</script>

<!-- Add "scoped" attribute to 
limit CSS to this component only -->
<style scroped>

</style>
