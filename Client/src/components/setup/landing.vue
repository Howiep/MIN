<template>
  <v-card class="hello">
    <v-card-media src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Jordmor_jim-_oslo.jpeg/2560px-Jordmor_jim-_oslo.jpeg" height="200px">
    </v-card-media>
    <v-card-title>
    <h3>{{ msg }}</h3>
    </v-card-title>
    <v-card-actions>
    <v-btn class="primary" dark to="register" >Register</v-btn>
    <v-btn class="primary" dark to="login" >Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: 'landing',
  data () {
    return {
      msg: 'My Internship Notation'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
