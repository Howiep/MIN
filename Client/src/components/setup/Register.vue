<template>
   <v-container xs-fluid>
   <v-layout>
     <v-flex>
      <div>
        <v-toolbar color="transparent" flat>
            <v-toolbar-title>
              Opret en bruger
            </v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form name="tab-tracker-form" autocomplete="off" v-model="valid">
              <v-text-field required :rules="emailRules" name="email" label="Email" v-model="email"></v-text-field>
              <v-text-field required class="frmField" autocomplete="new-password" type="password" name="password" label="Password" @input="password_check" v-model="password"></v-text-field>
              <div class="black--text">
                <div class="frmValidation">Koden skal indeholde:</div>
                <div class="frmValidation" :class="{'frmValidation--passed' : password.length > 7}">
                      <v-icon v-if="password.length > 7">check_circle</v-icon>
                    min. 6 tegn
                    </div>
                <div class="frmValidation" :class="{'frmValidation--passed' :has_uppercase }">
                      <v-icon v-if="has_uppercase">check_circle</v-icon>
                  Store Bogstaver
                </div>
                <div class="frmValidation" :class="{'frmValidation--passed' :has_lowercase }">
                      <v-icon v-if="has_lowercase">check_circle</v-icon>
                  Små bogstaver
                   </div>
                <div class="frmValidation" :class="{'frmValidation--passed' :has_number }">
                      <v-icon v-if="has_number">check_circle</v-icon>
                  Tal
                  </div>
              </div>
              <v-btn block large :loading="loading" :disabled="loading" color="accent" @click.native="register" >
                              Opret bruger
              </v-btn>
               <v-btn block :loading="loading" :disabled="loading" color="primary" flat to="login" >
                              login
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
  name: 'register',
  data () {
    return {
      valid: false,
      email: '',
      password: '',
      loading: false,
      emailRules:
      [
        v => !!v || 'E-mail is required',
        v => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail must be valid'
      ],
      has_number: false,
      has_lowercase: false,
      has_uppercase: false
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
        this.$store.dispatch('setUser', response.data)
        this.$store.dispatch('toggleSnackbar', { message: 'Succes! Du er logget ind', snackColor: 'accent', snackbarStatus: true, timeout: 2500, })
        this.loading = false
      } catch (error) {
        //console.log(error)
        this.loading = false
      }
      this.$router.push({ path: 'home' })
    },
    password_check: function () {
      this.has_number = /\d/.test(this.password)
      this.has_lowercase = /[a-z]/.test(this.password)
      this.has_uppercase = /[A-Z]/.test(this.password)
    }
  }
}
</script>

<!-- Add "scoped" attribute to
limit CSS to this component only -->
<style scoped>
.frmValidation{
  font-size: 12px;
}
.frmValidation--passed{
  color: green;
  }
.container{
  height: 100vh;
}
</style>
