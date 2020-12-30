<template>

  <div>
    <v-file-input show-size label="File input" accept="video/*" @change="handleFile"></v-file-input>

    <div v-if="tricks">
      <p v-for="t in tricks">
        {{ t.name }} </p>
    </div>

    <v-text-field v-model="trickName"></v-text-field>
    <v-btn @click="saveTrick">Save trick</v-btn>
    <v-stepper v-model="step">
      <v-stepper-header>
        <v-stepper-step :complete="step > 1" step="1">
          Name of step 1
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step :complete="step > 2" step="2">
          Name of step 2
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">
          Name of step 3
        </v-stepper-step>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card class="mb-12" color="grey lighten-1" height="200px"></v-card>


        </v-stepper-content>

        <v-stepper-content step="2">
          <v-card class="mb-12" color="grey lighten-1" height="200px"></v-card>


        </v-stepper-content>

        <v-stepper-content step="3">
          <v-card class="mb-12" color="grey lighten-1" height="200px"></v-card>

        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
    <v-btn @click="resetTricks">Reset tricks</v-btn>
  </div>
</template>

<script>

import {mapState, mapActions, mapMutations} from 'vuex'
import Axios from "axios";

export default {

  data: () => ({
    trickName: "",
    step: 1
  }),
  computed: {
    ...mapState('tricks', {
      tricks: state => state.tricks
    })
  },
  methods: {
    ...mapMutations('tricks', {
      resetTricks: 'reset'
    }),
    ...mapActions('tricks', ['createTrick']),
    async saveTrick() {

      await this.createTrick({trick: {name: this.trickName}})
    },
    async handleFile(file) {
      if (!file)
        return;
      console.log(file)
      const result = new FormData();
      result.append("video", file)
      await Axios.post('http://localhost:5000/api/videos', result);
    }
  }
}
</script>
