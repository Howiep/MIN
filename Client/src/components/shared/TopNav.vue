<template>
    <v-toolbar absolute app dark class="primary">
    <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->
    <v-btn dark to="home">LOGO</v-btn>
    <v-toolbar-title>{{ currentPage }}</v-toolbar-title>
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
import MenuService from '@/services/MenuService'

export default {
  data () {
    return {
      e1: null,
      menuItems: [],
      currentPage: ''
    }
  },
  async mounted () {
    this.updateMenu()
  },
  watch: {
    $route (to, from) {
      this.updateMenu()
    }
  },
  methods: {
    updateMenu () {
      try {
        this.menuItems = MenuService.get()
        this.currentPage = MenuService.getText(this.$route.path)
      } catch (error) {
        // todo: proper errorhandling
        this.message = 'error'
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to
limit CSS to this component only -->
<style scroped>

</style>
