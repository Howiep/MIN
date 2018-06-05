<template>
  <v-toolbar fixed app dark class="primary" >
    <v-toolbar-title>
      <div class="logo">
        <img src="../../assets/Logo_w.png">
      </div>
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items class="hidden-sm-and-down">
        <v-btn v-for="item in menuItems" :key="item.order" flat dark :value="item.value" :to="item.path" >
          <v-icon>{{ item.icon }}</v-icon>
          <span>{{ item.text }}</span>
        </v-btn>
        <v-btn flat href="/#/">home</v-btn>
        <!-- <v-btn v-if="this.isLoggedIn" flat @click="logout">Log out</v-btn>
        <v-btn v-if="!this.isLoggedIn" flat href="/#/register">Sign up</v-btn>
        <v-btn v-if="!this.isLoggedIn" class="primary" href="/#/login">Login</v-btn> -->
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
import store from '@/store'
import MenuService from '@/services/MenuService'

export default {
  data () {
    return {
      e1: null,
      menuItems: []
    }
  },
  async mounted () {
    this.updateMenu()
  },
  methods: {
    async updateMenu () {
      try {
        this.menuItems = await MenuService.get()
      } catch (error) {
        // todo: proper errorhandling
        this.message = 'error'
      }
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
<style scoped>
.logo img{
  max-height: 56px;
  padding: 15px 0 10px 0;
}
</style>
