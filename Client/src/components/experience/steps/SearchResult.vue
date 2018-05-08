<template>


</template>

<script>
import ExperienceService from '@/services/ExperienceService'

export default {
  name: 'chooseExperience',
  data () {
    return {
      selected: [],
      experienceList: [],
      currentItem: 'tab-0'
    }
  },
  async mounted () {
    try {
      const res = await ExperienceService.getCategories()
      this.experienceList = res
    } catch (error) {
      // this.message = error.response.data.error
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.chooseList{
  max-height: calc(100vh - 400px);
}
</style>