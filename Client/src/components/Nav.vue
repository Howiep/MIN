<template>
     <v-bottom-nav absolute :value="true" :active.sync="e1" color="transparent">
      <v-btn flat color="teal" value="recent">
        <span>Recent</span>
        <v-icon>history</v-icon>
      </v-btn>
      <v-btn flat color="teal" value="favorites">
        <span>Favorites</span>
        <v-icon>favorite</v-icon>
      </v-btn>
      <v-btn flat color="teal" value="nearby">
        <span>Nearby</span>
        <v-icon>place</v-icon>
      </v-btn>
    </v-bottom-nav>
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
      e1: null
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
}
</script>

<!-- Add "scoped" attribute to 
limit CSS to this component only -->
<style>

</style>
