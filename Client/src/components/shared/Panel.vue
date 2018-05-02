<template>
  <div class="white elevation-2">
       <v-toolbar flat dense class="pink" dark>
         <v-toolbar-title>
           {{title}}
         </v-toolbar-title>
       </v-toolbar>
       <div class="pl-4 pr-4 pt-2 pb-2">
         <slot>
           no content
         </slot>
       </div>
     </div>
</template>
<script>
export default {
  name: 'panel',
  props: [
    'title'
  ]
}
</script>
<style>

</style>
