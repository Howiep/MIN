<template>
<div>
  <v-toolbar color="transparent" flat tabs>
    <v-text-field v-model="search" append-icon="search" label="Søg" solo-inverted flat></v-text-field>
    <v-tabs v-if="!search" fixed-tabs v-model="currentItem" color="transparent" slider-color="accent" slot="extension">
      <v-tab v-for="item in experienceList" :key="item.id" :href="'#tab-' + item.id">
        {{ item.name }}
      </v-tab>
    </v-tabs>
  </v-toolbar>
  <v-tabs-items v-model="currentItem" class="actionList">
    <v-tab-item v-for="item in experienceList" :key="item.id" :id="'tab-' + item.id">
      <v-card v-if="!search" class="scroll-y chooseList">
        <v-list-tile ripple @click="toggle(i)" v-for="i in item.actions" :key="i.index" avatar>
            <v-list-tile-content>
              <v-list-tile-title>{{ i }}</v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action>
              <v-icon color="grey lighten-1" v-if="selected.indexOf(i) < 0">check_box_outline_blank</v-icon>
              <v-icon color="underline" v-else>check_box</v-icon>
            </v-list-tile-action>
        </v-list-tile>
      </v-card>
      <v-card v-if="search" class="scroll-y chooseList">
        <v-list-tile ripple @click="toggle(i)" v-for="i in filteredList" :key="i" avatar>
            <v-list-tile-content>
              <v-list-tile-title>{{ i }}</v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action>
              <v-icon color="grey lighten-1" v-if="selected.indexOf(i) < 0">check_box_outline_blank</v-icon>
              <v-icon color="underline" v-else>check_box</v-icon>
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
      search: '',
      actions: new Set(), // using Set() is ES6, automatically makes sure there are only unique values
      selected: [],
      experienceList: [],
      currentItem: 'tab-0'
    }
  },
  async mounted () {
    try {
      const res = await ExperienceService.getCategories()
      this.experienceList = res

      // extract actions from categories
      res.forEach(experienceList => {
        experienceList.actions.forEach(actions => {
          this.actions.add(actions)
        })
      })
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
      this.$emit('setExperiences', this.selected)
    }
  },
  computed: {
    filteredList () {
      const array = Array.from(this.actions)
      return array.filter(action => {
        return action.toLowerCase().includes(this.search.toLowerCase())
      })
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