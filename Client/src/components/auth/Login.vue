<template>
 <v-container xs-fluid>
 <v-layout>
   <v-flex>
     <div>
        <v-toolbar color="transparent" flat>
            <v-toolbar-title>
              Login
            </v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form name="tab-tracker-form" autocomplete="off">
              <v-text-field required name="email" label="Email" v-model="email"></v-text-field>
              <v-text-field required autocomplete="new-password" type="password" name="password" label="Password" v-model="password"></v-text-field>
              <v-btn block large :loading="loading" :disabled="loading" color="accent" @click.native="login" >
                  Login
              </v-btn>
            </v-form>
          </v-card-text>
      </div>
   </v-flex>
 </v-layout>
  <v-snackbar
              :timeout="timeout"
              :color="snackColor"
              vertical
              v-model="snackbar" >
              {{ message }}
              <v-btn dark flat @click.native="snackbar = false">Close</v-btn>
  </v-snackbar>
 </v-container>
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
        this.$store.dispatch('setUser', response.data.userName)
        console.log(response)
        this.loading = false
        this.snackbar = true
        this.snackColor = 'accent'
        this.message = 'success: du er logget ind'
        this.$router.push('home')
      } catch (error) {
        this.loading = false
        this.snackbar = true
        this.snackColor = 'red'
        this.message = 'Der skete en fejl'
        console.log(error)
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
