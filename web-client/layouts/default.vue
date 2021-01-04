<template>
  <v-app dark>
    <v-app-bar app dense>
      <v-toolbar-title>Tricking library</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn @click="toggleActivity" depressed>
        UPLOAD
      </v-btn>
    </v-app-bar>
    <video-upload/>
    <v-main>
      <nuxt/>
    </v-main>
  </v-app>
</template>
<script>
import {mapMutations} from 'vuex'
import VideoUpload from '~/components/video-upload'
export default {
  methods: mapMutations('video-upload', ['toggleActivity']),
  components : {VideoUpload}
}
</script>
