<template>
  <v-app dark>
    <v-app-bar app dense>
      <v-toolbar-title>Tricking library</v-toolbar-title>
      <v-spacer></v-spacer>
<!--      <v-btn @click="toggleActivity" depressed>-->
<!--        UPLOAD-->
<!--      </v-btn>-->
    </v-app-bar>
    <content-creation/>
    <v-main>
      <nuxt/>

    </v-main>
  </v-app>
</template>
<script>
import {mapMutations} from 'vuex'
import ContentCreation from '../components/content-creation/content-creation-dialog'
export default {

  components : {ContentCreation}
}
</script>
