<template>
 <v-layout>
   <v-flex xs6 offset-xs3>
    <panel title="Register">
         <br>
         <form name="tab-tracker-form" autocomplete="off">
            <v-text-field name="email" label="Email" v-model="email"></v-text-field>          
           <v-text-field autocomplete="new-password" type="password" name="password" label="Password" v-model="password"></v-text-field>          
         </form>
           <br>
          <br>
          <div v-if="!this.loading">
            <v-btn class="cyan" dark @click="register" >Register</v-btn>
          </div>
          <div v-if="this.loading" >
            <br>
            <v-progress-circular indeterminate color="green"></v-progress-circular>
          </div>
          <div class="error" v-html="message"></div>
          <br>
    </panel>
   </v-flex>
 </v-layout>
</template>

<script>
import AuthenticationService from '@/services/AuthenticationService'
import Panel from '@/components/Panel'

export default {
  name: 'register',
  data () {
    return {
      email: '',
      password: '',
      loading: false,
      message: null
    }
  },
  methods: {
    async register () {
      try {
        this.loading = true
        const response = await AuthenticationService.register({
          email: this.email,
          password: this.password
        })
        this.$store.dispatch('setToken', response.data.token)
        this.$store.dispatch('setUser', response.data.user)
        this.message = 'success'
        this.loading = false
      } catch (error) {
        this.loading = false
        this.message = error.response.data.error
      }
    }
  },
  components: {
    Panel
  }
}
</script>

<!-- Add "scoped" attribute to 
limit CSS to this component only -->
<style>

</style>
