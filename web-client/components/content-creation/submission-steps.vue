<template>
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 1" step="1">
        Upload video
      </v-stepper-step>
      <v-divider></v-divider>

      <v-stepper-step :complete="step > 2" step="2">
        Select trick
      </v-stepper-step>
      <v-divider></v-divider>

      <v-stepper-step :complete="step > 2" step="2">
        Trick information
      </v-stepper-step>
      <v-divider></v-divider>

      <v-stepper-step :complete="step > 4" step="4">
        Submission
      </v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="5">
        Confirmation
      </v-stepper-step>
    </v-stepper-header>
    <v-stepper-items>
      <v-stepper-content step="1">
        <v-file-input show-size label="File input" accept="video/*" @change="handleFile"></v-file-input>
      </v-stepper-content>
      <v-stepper-content step="2">
        <div>
          <v-select v-model="form.trickId" :items="trickItems" label="Select trick"></v-select>
          <v-btn @click="step++">Next</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="3">
        <v-text-field v-model="form.description"></v-text-field>
        <v-btn @click="step++">Next</v-btn>
      </v-stepper-content>
      <v-stepper-content step="4">
        Success
        <v-btn @click="save">Save</v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>

</template>

<script>
import {mapGetters, mapActions, mapMutations} from 'vuex'

const initState = {
  form: {
    trickId: "",
    description: "",
    video: "",
  },
  step: 1

}
export default {
  name: "submission-steps",
  data: initState,
  computed: {
    ...mapGetters('tricks', ['trickItems']),

  },
  methods: {
    ...mapMutations('video-upload', ['reset']),
    ...mapActions('video-upload', ['uploadVideo', 'createSubmission']),
    async handleFile(file) {
      if (!file)
        return;
      const form = new FormData();
      form.append("video", file)
      console.log({form})
      await this.uploadVideo({form});
      this.step++;
    },

    async save() {

      this.form.video = await this.uploadPromise;

      await this.createSubmission({form: this.form})
      this.reset();
      Object.assign(this.$data, initState)
    },
  }
}
</script>

<style scoped>

</style>
