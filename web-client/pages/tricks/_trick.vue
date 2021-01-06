<template>
  <div>

    <div>
      Trick: {{ $route.params.trick }}
    </div>
    <div>
      <div v-if="submissions">
        <div v-for="s in submissions">
          {{ s.description }}

          <video width="400" controls :src="`http://localhost:5000/api/videos/${s.video}`"></video>

        </div>
      </div>
    </div>
  </div>

</template>

<script>
import {mapState} from 'vuex';
export default {
  computed : mapState('submissions', ['submissions']),
  name: "trick",
  methods:{
    async fetch(){
      const trickId = this.$route.params.trick;
      console.log(trickId)
       await this.$store.dispatch("submissions/fetchSubmissionsForTrick", {trickId}, {root: true})
    }
  }
}
</script>

<style scoped>

</style>
