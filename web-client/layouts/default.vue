<template>
  <v-app dark>
    <v-app-bar app dense>
      <v-toolbar-title>Tricking library</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn @click="toggleActivity" depressed>
        UPLOAD
      </v-btn>
    </v-app-bar>
    <v-main>
      <nuxt/>
    </v-main>
  </v-app>
</template>
<script>
import {mapMutations} from 'vuex'
export default {
  methods: mapMutations('videos', ['toggleActivity']),
}
</script>
