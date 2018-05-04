<template>
    <v-toolbar app dark class="primary">
    <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->
    <v-toolbar-title>M.I.N</v-toolbar-title>
    <v-toolbar-title>{{  }}</v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items  v-for="item in menuItems" :key="item.order" class="hidden-sm-and-down">
        <v-btn flat dark :value="item.value" :to="item.path" >
          <v-icon>{{ item.icon }}</v-icon>
          <span>{{ item.text }}</span>
        </v-btn>
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
      menuItems: [
        { order: 1, value: 'home', text: 'Hjem', path: 'home', icon: 'home' },
        { order: 2, value: 'experiences', text: 'Erfaringer', path: 'experiences', icon: 'list' },
        { order: 3, value: 'feed', text: 'Feed', path: 'feed', icon: 'notifications_none' },
        { order: 4, value: 'user', text: 'Bruger', path: 'user', icon: 'person_outline' }
      ]
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
