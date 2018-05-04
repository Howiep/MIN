<template>
  <v-card class="hello">
    <v-card-media v-bind:src="imageLink" height="200px">
    </v-card-media>
    <v-card-title>
    <h3>{{ msg }}</h3>
    </v-card-title>
    <v-card-text>{{ welcome }}</v-card-text>
    <v-card-actions>
    <v-btn class="primary" dark to="experience" >Lad os gå igang</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: 'IntroPage',
  data () {
    return {
      imageLink: '/static/img/banner.png',
      msg: 'Hej, Jeg er M.I.N',
      welcome: 'Det er første gang vi mødes. Hjælp mig med at forstå dine priotiteter. Vælg de læringsmål du vil fokusere på  igennem dit praktikforløb.'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
