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
          <div>
            <v-btn :loading="loading" :disabled="loading" color="primary" @click.native="login" >
              Login
            </v-btn>
          </div>
          <v-snackbar
            :timeout="timeout"
            :color="snackColor"
            multi-line
            v-model="snackbar" >
            {{ message }}
            <v-btn dark flat @click.native="snackbar = false">Close</v-btn>
          </v-snackbar>
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
      message: null,
      snackbar: false,
      timeout: 2000,
      snackColor: 'primary'
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
        this.loading = false
        this.snackbar = true
        this.snackColor = 'accent'
        this.message = 'success: du er logget ind'
      } catch (error) {
        this.loading = false
        this.snackbar = true
        this.snackColor = 'red'
        this.message = 'Der skete en fejl'
        console.log(error.response.data.error)
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
