<template>
<v-container xs-fluid>
   <v-layout>
     <v-flex>
         <v-card flat>
          </v-card-media>
          <v-card-title>
          <h1>{{ msg }}</h1>
          </v-card-title>
          <v-card-text>Velkommen til IN</v-card-text>
          <v-card-actions>
          <v-btn block large class="primary" dark to="register" >Opret ny bruger</v-btn>
          </v-card-actions>
          <v-card-actions>
          <v-btn block large class="accent" dark to="login" >Login</v-btn>
          </v-card-actions>
        </v-card>
    </v-flex>
   </v-layout>
</v-container>
</template>

<script>
export default {
  name: 'landingPage',
  data () {
    return {
      msg: 'My Internship Notation'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.application .theme--light.card, .theme--light .card{
  background-color: transparent;
}
</style>
