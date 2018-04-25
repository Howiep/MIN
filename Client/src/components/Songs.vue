<template>
 <v-layout>
   <v-flex xs6 offset-xs3>
     <panel title="Songs">
       <div v-for="song in songs" :key="song.title">
         {{song.title}}
         <br>
         {{song.artist}}
         <br>
         {{song.album}}
         <hr>
       </div>
     </panel>
   </v-flex>
 </v-layout>
</template>

<script>
import Panel from '@/components/Panel'
import SongsService from '@/services/SongsService'

export default {
  components: {
    Panel
  },
  data () {
    return {
      songs: null
    }
  },
  async mounted () {
    // request all songs from server
    this.songs = await SongsService.getAllSongs()
  }
}
</script>

<!-- Add "scoped" attribute to 
limit CSS to this component only -->
<style>

</style>
