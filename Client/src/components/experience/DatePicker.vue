<template>
  <div class="hello">
    <h3>{{ msg }}</h3>
      <v-btn color="primary" dark @click.stop="dialog = true">Open Dialog 1</v-btn>
  </div>
</template>

<script>
export default {
  name: 'DatePicker',
  data () {
    return {
      msg: 'Vælg dato'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
