<template>
    <v-layout>
    <v-flex>
      <div class="hello">
          <h1>{{ msg }}</h1>
          <h2>Homepage</h2>
      </div>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  name: 'home',
  data () {
    return {
      msg: 'Bruger'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
