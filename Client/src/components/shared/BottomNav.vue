<template>
     <v-bottom-nav app absolute :value="true" :active.sync="e1" color="white">
       <div v-for="item in menuItems" :key="item.order">
        <v-btn flat color="primary" :value="item.value" :to="item.path" >
          <!-- <span>{{ item.text }}</span> -->
          <v-icon>{{ item.icon }}</v-icon>
        </v-btn>
       </div>
    </v-bottom-nav>
    <!-- <v-toolbar-items>
        <v-btn flat href="/#/">home</v-btn>
        <v-btn v-if="this.isLoggedIn" flat @click="logout">Log out</v-btn>
        <v-btn v-if="!this.isLoggedIn" flat href="/#/register">Sign up</v-btn>
        <v-btn v-if="!this.isLoggedIn" class="primary" href="/#/login">Login</v-btn>
    </v-toolbar-items> -->
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
    try {
      const res = await MenuService.get()
      this.menuItems = res
    } catch (error) {
      this.message = error.response.data.error
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
<style scroped>
v-bottom-nav{
  max-width: 100vw;
}
</style>
