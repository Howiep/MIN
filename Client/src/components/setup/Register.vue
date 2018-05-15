<template>
   <v-container>
   <v-layout>
     <v-flex>
      <v-card>
        <v-toolbar color="primary" dark flat>
            <v-toolbar-title>
              Registrer en bruger
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
            </v-form>
          </v-card-text>
      </v-card>
    </v-flex>
   </v-layout>
   <v-toolbar>
        <v-btn :loading="loading" :disabled="loading" color="primary" @click.native="register" >
                Register
        </v-btn>
   </v-toolbar>
    <v-snackbar
              :timeout="timeout"
              :color="snackColor"
              multi-line
              v-model="snackbar" >
              {{ message }}
              <v-btn dark flat @click.native="snackbar = false">Close</v-btn>
    </v-snackbar>
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
      message: null,
      snackbar: false,
      timeout: 3000,
      snackColor: 'primary',
      emailRules: [
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
        this.$store.dispatch('setToken', response.data.token)
        this.$store.dispatch('setUser', response.data.user)
        this.loading = false
        this.snackbar = true
        this.snackColor = 'accent'
        this.message = 'success: du er logget ind'
      } catch (error) {
        console.log(error)
        this.loading = false
        this.snackbar = true
        this.snackColor = 'red'
        this.message = 'Der skete en fejl'
      }
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
</style>
