<template>
<div>
  <v-toolbar color="transparent" flat tabs>
    <v-text-field v-model="search" append-icon="search" label="Søg" solo-inverted flat></v-text-field>
    <v-tabs v-if="!search" v-model="currentItem" color="transparent" slider-color="accent" slot="extension">
      <v-tab v-for="item in categories" :key="item.id" :href="'#tab-' + item.id">
        {{ item.name }}
      </v-tab>
    </v-tabs>
  </v-toolbar>
  <v-tabs-items v-model="currentItem" class="actionList">
    <v-tab-item v-if="!search" v-for="item in categories" :key="item.id" :id="'tab-' + item.id">
      <v-card  class="scroll-y chooseList">
        <v-list two-line subheader>
          <v-list-tile v-for="experience in currentTabItems" :key="experience.id" ripple @click="toggle(experience)">
              <v-list-tile-content>
                <v-list-tile-sub-title>{{ experience.name }}</v-list-tile-sub-title>
              </v-list-tile-content>
              <v-list-tile-action>
                <v-icon color="grey lighten-1" v-if="selected.indexOf(experience) < 0">check_box_outline_blank</v-icon>
                <v-icon color="underline" v-else>check_box</v-icon>
              </v-list-tile-action>
            </v-list-tile>
        </v-list>
      </v-card>
    </v-tab-item>
      <v-card v-if="search" class="scroll-y chooseList">
        <v-list two-line subheader>
          <v-list-tile v-for="experience in filteredList" :key="experience.id" ripple @click="toggle(experience)">
              <v-list-tile-content>
                <v-list-tile-sub-title>{{ experience.name }}</v-list-tile-sub-title>
              </v-list-tile-content>
              <v-list-tile-action>
                <v-icon color="grey lighten-1" v-if="selected.indexOf(experience) < 0">check_box_outline_blank</v-icon>
                <v-icon color="underline" v-else>check_box</v-icon>
              </v-list-tile-action>
            </v-list-tile>
        </v-list>
      </v-card>
  </v-tabs-items>
</div>

</template>

<script>
import ExperienceService from '@/services/ExperienceService'

export default {
  name: 'chooseExperience',
  data () {
    return {
      search: '',
      actions: new Set(), // using Set() is ES6, automatically makes sure there are only unique values
      selected: [],
      experiences: [],
      categories: [],
      currentItem: ''
    }
  },
  async mounted () {
    try {
      const experiences = await ExperienceService.get()
      const categoryList = await ExperienceService.getCategories()

      this.experiences = experiences.data
      this.categories = categoryList.data

    } catch (error) {
      // this.message = error.response.data.error
    }
    this.currentItem = 'tab-' + this.categories[0].id // set tab-number to first in array
  },
  methods: {
    toggle (value) {
      const i = this.selected.indexOf(value)
      if (i > -1) {
        this.selected.splice(i, 1)
      } else {
        this.selected.push(value)
      }
      this.$emit('setExperiences', this.selected)
    }
  },
  computed: {
    currentTabItems () {
      return this.experiences.filter(experience => {
        return experience.experienceCategory.id == parseInt(this.currentItem.substring(4,5))
      })
    },
    filteredList () {
      const array = Array.from(this.experiences)
      return this.experiences.filter(experience => {
        return experience.name.toLowerCase().includes(this.search.toLowerCase())
      })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.chooseList{
    max-height: calc(100vh - 340px);
}
.list__tile__sub-title, .list__tile__title{
  color: #333333!important;
  white-space: unset;
  overflow: unset;
}
</style>
