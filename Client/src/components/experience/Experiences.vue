<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>Homepage</h2>
    <add-dialog></add-dialog>
  </div>
</template>

<script>
import AddDialog from '@/components/experience/AddExperience'

export default {
  name: 'experiences',
  data () {
    return {
      msg: 'Experiences'
    }
  },
  components: {
    AddDialog
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

</style>
