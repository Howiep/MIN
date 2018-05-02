<template>
 <v-layout>
   <v-flex>
     <panel title="Login">
       <br>
         <form name="tab-tracker-form" autocomplete="off">
            <v-text-field name="email" label="Email" v-model="email"></v-text-field>          
            <v-text-field type="password" name="password" label="Password" v-model="password"></v-text-field>
          </form>          
          <br>
          <br>
          <div v-if="!this.loading">
            <v-btn class="primary" dark @click="login" >Login</v-btn>
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
import Panel from '@/components/shared/Panel'

export default {
  name: 'login',
  data () {
    return {
      email: '',
      password: '',
      loading: false,
      message: null
    }
  },
  methods: {
    async login () {
      try {
        this.loading = true
        const response = await AuthenticationService.login({
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
