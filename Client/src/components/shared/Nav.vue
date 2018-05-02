<template>
     <v-bottom-nav absolute shift :value="true" :active.sync="e1" color="transparent">
      <v-btn flat color="primary" value="recent" >
        <span>Recent</span>
        <v-icon>trending_up</v-icon>
      </v-btn>
      <v-btn flat color="primary" value="list">
        <span>List</span>
        <v-icon>list</v-icon>
      </v-btn>
      <v-btn flat color="primary" value="add">
        <span>Add</span>
        <v-icon>add_circle_outline</v-icon>
      </v-btn>
      <v-btn flat color="primary" value="aktivitet">
        <span>Aktivitet</span>
        <v-icon>notifications_none</v-icon>
      </v-btn>
      <v-btn flat color="primary" value="nearby">
        <span>Social</span>
        <v-icon>person_outline</v-icon>
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
<style scroped>
v-bottom-nav{
  max-width: 100vw;
}
</style>
