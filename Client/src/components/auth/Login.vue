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
            <v-form name="tab-tracker-form">
              <v-text-field required  name="email" label="Email" v-model="email"></v-text-field>
              <v-text-field required type="password" name="password" label="Password" v-model="password"></v-text-field>
              <v-btn block large :loading="loading" :disabled="loading" color="accent" @click.native="login" >
                  Login
              </v-btn>
              <v-btn block :loading="loading" :disabled="loading" color="primary" flat to="register" >
                  Opret bruger
              </v-btn>
            </v-form>
          </v-card-text>
      </div>
    </v-flex>
   </v-layout>
 </v-container>
</template>

<script>
import AuthenticationService from '@/services/AuthenticationService'

export default {
  name: 'login',
  data () {
    return {
      email: '',
      password: '',
      loading: false,
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
        this.$store.dispatch('setUser', response.data)
        this.$store.dispatch('toggleSnackbar', { message: 'Succes! Du er logget ind', snackColor: 'accent', snackbarStatus: true, timeout: 2500, })
        this.loading = false
      } catch (error) {
        //console.log(error)
        this.loading = false
      }
      this.$router.push({ path: 'home' })
    }
  },
  components: {
  }
}
</script>

<!-- Add "scoped" attribute to
limit CSS to this component only -->
<style>

</style>
