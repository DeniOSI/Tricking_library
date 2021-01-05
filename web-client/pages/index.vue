<template>
  <div>
    <div v-if="tricks">
      <div v-for="t in tricks">
        <div v-if="submissions">
          <div v-for="s in submissions">
            <div v-if="t.id === s.trickId">
            {{t.name}} :  {{s.description}}
            <v-divider></v-divider>

            <video width="400" controls :src="`http://localhost:5000/api/videos/${s.video}`"></video>
              </div>
          </div>
        </div>
      </div>
    </div>

<!--    <div v-if="submissions">-->
<!--      <div v-for="s in submissions">-->
<!--        {{ s.description }}-->
<!--        <div>-->
<!--          <video width="400" controls :src="`http://localhost:5000/api/videos/${s.video}`"></video>-->
<!--        </div>-->
<!--      </div>-->
<!--    </div>-->
  </div>

</template>

<script>

import {mapState} from 'vuex'
export default {
  data: () => ({
  }),
  computed: {
    ...mapState('tricks', ['tricks']),
    ...mapState('submissions', ['submissions']),
  },
  methods: {
  },

}
</script>
