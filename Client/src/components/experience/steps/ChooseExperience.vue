<template>
<div>
  <v-toolbar color="transparent" flat tabs>
    <v-text-field v-model="search" append-icon="search" label="Søg" solo-inverted flat></v-text-field>
    <v-tabs v-if="!search" fixed-tabs v-model="currentItem" color="transparent" slider-color="accent" slot="extension">
      <v-tab v-for="item in categories" :key="item.id" :href="'#tab-' + item.id">
        {{ item.name }}
      </v-tab>
    </v-tabs>
  </v-toolbar>
  <v-tabs-items v-model="currentItem" class="actionList">
    <v-tab-item v-for="item in categories" :key="item.id" :id="'tab-' + item.id">

      <v-card v-if="!search" class="scroll-y chooseList">
        <v-list three-line subheader>
          <v-subheader>{{ item.name }}</v-subheader>
          <v-list-tile v-for="item in experiences" :key="item.id">
            <v-list-tile-content>
              <v-list-tile-title>{{ item.name }}</v-list-tile-title>
              <v-list-tile-sub-title>Set the content filtering level to restrict appts that can be downloaded</v-list-tile-sub-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
        <!-- <v-list>
          <v-list-group
            v-for="group in item.groups"
            v-model="group.active"
            :key="group.name"
            no-action
          >
            <v-list-tile slot="activator" @click="toggle(group.actions)">
              <v-list-tile-content>
                <v-list-tile-title>{{ group.name }}</v-list-tile-title>
              </v-list-tile-content>
              <v-list-tile-action>
                <v-icon color="grey lighten-1" v-if="selected.indexOf(group.actions) < 0">check_box_outline_blank</v-icon>
                <v-icon color="underline" v-else>check_box</v-icon>
              </v-list-tile-action>
            </v-list-tile>
            <v-list-tile v-for="action in group.actions" :key="action.index" ripple @click="toggle(action)">
              <v-list-tile-content>
                <v-list-tile-title>{{ action }}</v-list-tile-title>
              </v-list-tile-content>
              <v-list-tile-action>
                <v-icon color="grey lighten-1" v-if="selected.indexOf(action) < 0">check_box_outline_blank</v-icon>
                <v-icon color="underline" v-else>check_box</v-icon>
              </v-list-tile-action>
            </v-list-tile>
          </v-list-group>

        </v-list> -->
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
      experiences: new Set(),
      categories: [],
      currentItem: ''
    }
  },
  async mounted () {
    try {
      const experiences = await ExperienceService.get()
      const categoryList = await ExperienceService.getCategories()
      const actionsList = await ExperienceService.getActions()

      this.experiences = experiences.data
      this.categories = categoryList.data
      this.actions = actionsList.data

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
        if (value.count > 0) {
          value.forEach(action => {
            console.log(action)
                this.selected.push(action)
            })
        }
        this.selected.push(value)
      }
      this.$emit('setExperiences', this.selected)
    }
  },
  computed: {
    currentTabItems () {
      const array = Array.from(this.experiences)
      return array.filter(action => {
        return experiences.experienceCategory.id.filter(l => l.id === this.currentItem.split(0,3))
      })
    },
    filteredList () {
      const array = Array.from(this.actions)
      return array.filter(action => {
        return action.name.toLowerCase().includes(this.search.toLowerCase())
      })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.chooseList{
    max-height: calc(100vh - 320px);

}
</style>
