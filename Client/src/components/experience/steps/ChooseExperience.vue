<template>
<div>
  <v-toolbar color="transparent" flat tabs>
    <v-text-field append-icon="search" label="Søg" solo-inverted flat></v-text-field>
    <v-tabs fixed-tabs v-model="currentItem" color="transparent" slider-color="yellow" slot="extension">
      <v-tab v-for="item in experienceList" :key="item.id" :href="'#tab-' + item.id">
        {{ item.name }}
      </v-tab>
    </v-tabs>
  </v-toolbar>
  <v-tabs-items v-model="currentItem">
    <v-tab-item v-for="item in experienceList" :key="item.id" :id="'tab-' + item.id">
      <v-card class="scroll-y chooseList">
        <v-list-tile @click="toggle(i)" v-for="i in item.actions" :key="i" avatar>
            <v-list-tile-content>
              <v-list-tile-title>{{ i }}</v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action>
              <v-btn icon ripple>
                <v-checkbox color="grey lighten-1">check</v-checkbox>
              </v-btn>
            </v-list-tile-action>
        </v-list-tile>
      </v-card>
    </v-tab-item>
  </v-tabs-items>
</div>

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
  },
  methods: {
    toggle (value) {
      const i = this.selected.indexOf(value)

      if (i > -1) {
        this.selected.splice(i, 1)
      } else {
        this.selected.push(value)
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.chooseList{
  max-height: 200px;
}
</style>