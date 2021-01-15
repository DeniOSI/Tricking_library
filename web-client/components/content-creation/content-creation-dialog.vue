<template>
  <div>
  <v-dialog :value="active" persistent>

      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn dark v-bind="attrs" v-on="on">
            Create
          </v-btn>
        </template>
        <v-list>
          <v-list-item v-for="(item, index) in menuItem" :key="`ccd-menu-${index}`" @click='activate(item.component)'>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

    <trick-steps/>
    <submission-steps/>


      <div v-if="component">
        <component :is="component"></component>
      </div>
    <div class="justify-center d-flex my-4">
      <v-btn @click="reset">Close</v-btn>
    </div>
  </v-dialog>
    Component: {{menuItem.map(x=>(x.component, x.title))}}
  </div>
</template>

<script>
import {mapState,  mapMutations} from 'vuex'
import TrickSteps from './trick-steps'
import SubmissionSteps from './submission-steps'

export default {
  name: "video-upload",

  computed: {
    ...mapState('video-upload', ['active', 'component']),
    menuItem() {
      return ([
        {component: TrickSteps, title: "Trick"},
        {component: SubmissionSteps, title: "Submissions"},
      ])
    }
  },
  methods: {
    ...mapMutations('video-upload', ['reset', 'activate']),

  },
  components: {TrickSteps, SubmissionSteps}
}
</script>

<style scoped>

</style>
